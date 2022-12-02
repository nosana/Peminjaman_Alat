using WebAPi.Context;
using WebAPi.Models;

namespace WebAPi.Repositories.Data
{
    public class StatusRepository : GeneralRepository<Status>
    {
        private MyContext myContext;
        public StatusRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
    }
}
