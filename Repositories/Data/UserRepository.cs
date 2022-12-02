using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using WebAPi.Context;
using WebAPi.Handlers;
using WebAPi.Models;
using WebAPi.ViewModel;

namespace WebAPi.Repositories.Data
{
    public class UserRepository : GeneralRepository<User>
    {
        private MyContext myContext;
        public UserRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        [HttpPost]
        public int Register(RegisterVM register)
        {
            User user = new User()
            {
                FullName = register.FullName,
                Gender = register.Gender,
                BirthDate = register.BirthDate,
                Address = register.Address,
                Phone = register.Phone,
                Email = register.Email,
                DepartmentId = register.DepartmentId
            };
            myContext.Users.Add(user);
            var data = myContext.Users.SingleOrDefault(x => x.Email.Equals(register.Email));
            if (data == null)
            {
                var result = myContext.SaveChanges();
                if (result > 0)
                {
                    var id = myContext.Users.SingleOrDefault(x => x.Email.Equals(register.Email)).Id;


                    Account accounts = new Account()
                    {

                        Id = id,
                        Password = Hashing.HashPassword(register.Password),


                    };
                    myContext.Accounts.Add(accounts);
                    var resultUser = myContext.SaveChanges();
                }
                return result;
            }
            return 0;
        
        }
    }
}
