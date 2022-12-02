using WebAPi.Context;
using WebAPi.Models;

namespace WebAPi.Repositories.Data
{
    public class DepartmentRepository:GeneralRepository<Department>
    {
        private MyContext myContext;
        public DepartmentRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
    }
}
