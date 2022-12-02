using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPi.Base;
using WebAPi.Models;
using WebAPi.Repositories.Data;

namespace WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnItemController : BaseController<ReturnItemRepository, ReturnItem>
    {
        private ReturnItemRepository _retutnItemRepository;
        public ReturnItemController(ReturnItemRepository repository) : base(repository)
        {
            _retutnItemRepository = repository; 
        }
    }
}
