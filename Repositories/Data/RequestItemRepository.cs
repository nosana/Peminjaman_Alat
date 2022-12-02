using WebAPi.Context;
using WebAPi.Models;

namespace WebAPi.Repositories.Data
{
    public class RequestItemRepository : GeneralRepository<RequestItem>
    {
        private MyContext myContext;
        public RequestItemRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
    }
}
