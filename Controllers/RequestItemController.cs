using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPi.Base;
using WebAPi.Models;
using WebAPi.Repositories.Data;

namespace WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestItemController : BaseController<RequestItemRepository, RequestItem>
    {
        private RequestItemRepository _requestItemRepository;
        public RequestItemController(RequestItemRepository repository) : base(repository)
        {
            _requestItemRepository = repository;
        }
    }
}
