using Microsoft.AspNetCore.Mvc;
using WarehouseAssistant.WebApi.Entities;
using WarehouseAssistant.WebApi.Repositories;

namespace WarehouseAssistant.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoragesController : ControllerBase
    {
        private readonly IStorageRepository _storageRepository;

        public StoragesController(IStorageRepository storageRepository)
        {
            _storageRepository = storageRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Storage>> Index()
        {
            return await _storageRepository.GetStoragesList();
        }
    }
}
