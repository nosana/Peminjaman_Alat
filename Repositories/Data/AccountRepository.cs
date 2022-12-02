using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPi.Context;
using WebAPi.Handlers;
using WebAPi.Models;
using WebAPi.ViewModel;

namespace WebAPi.Repositories.Data
{
    public class AccountRepository : GeneralRepository<Account>
    {
        private MyContext myContext;
        public AccountRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        [HttpPost]
        public ResponseLoginVm Login(LoginVM login)
        {
            ResponseLoginVm responseLogin = new ResponseLoginVm();
            var data = myContext.Users.Where(u => u.Email == login.Email).SingleOrDefault();
            if (data == null)
            {
                return responseLogin;
            }
            else
            {
                var result = myContext.Accounts.Where(a => a.Id == data.Id).SingleOrDefault();
                if (result == null)
                {
                    return responseLogin;
                }
                else
                {
                    var validatePass = Hashing.ValidatePassword(login.Password, result.Password);
                    if (validatePass)
                    {
                        var roles = myContext.Roles
                        .Where(r => r.Id == result.Id).SingleOrDefault();
                        

                        responseLogin.Id = data.Id;
                        responseLogin.FullName = data.FullName;
                        responseLogin.Email = data.Email;
                        responseLogin.Roles = roles.Name;

                        return responseLogin;
                    }
                }
            }
            return null;
        }

        /*public int ChangePassword(string Email, string Password, string Passnew)
        {
           var data = myContext.Users.Where(u => u.Email == Email).SingleOrDefault();
              
            if (data != null)
            {
                var pass = myContext.Accounts.Where(a => a.Password == Password).SingleOrDefault();
                if (Hashing.ValidatePassword(Password, pass.Password))
                {
                    pass.Password = Hashing.HashPassword(Passnew);
                    myContext.Entry(data).State = EntityState.Modified;
                    var result = myContext.SaveChanges();
                    if (result > 0)
                    {
                        return result;
                    }
                    return 0;
                }
                return 0;
            }

            return 0;
        }*/
    }
}
