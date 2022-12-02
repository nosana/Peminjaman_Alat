using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPi.Base;
using WebAPi.Models;
using WebAPi.Repositories.Data;

namespace WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : BaseController<StatusRepository, Status>
    {
        private StatusRepository _statusRepository;
        public StatusController(StatusRepository repository) : base(repository)
        {
            _statusRepository = repository;
        }
    }
}
