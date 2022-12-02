using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPi.Base;
using WebAPi.Models;
using WebAPi.Repositories.Data;

namespace WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : BaseController<ItemRepository, Item>
    {
        private ItemRepository ItemRepository;
        public ItemController(ItemRepository repository) : base(repository)
        {
            ItemRepository = repository; 
        }
    }
}
