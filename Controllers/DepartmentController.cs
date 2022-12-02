using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPi.Base;
using WebAPi.Models;
using WebAPi.Repositories.Data;

namespace WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : BaseController<DepartmentRepository, Department>
    {
        private DepartmentRepository _departmentRepository;
        public DepartmentController(DepartmentRepository repository) : base(repository)
        {
            _departmentRepository = repository;
        }
    }
}
