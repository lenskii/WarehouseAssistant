using Microsoft.AspNetCore.Mvc;
using WarehouseAssistant.WebApi.Entities;
using WarehouseAssistant.WebApi.Repositories;

namespace WarehouseAssistant.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;

        public ItemsController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Item>> Index()
        {
            return await _itemRepository.GetItemsList();
        }

    }
}