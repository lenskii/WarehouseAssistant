using Microsoft.EntityFrameworkCore;
using WarehouseAssistant.WebApi.DBContext;
using WarehouseAssistant.WebApi.Entities;

namespace WarehouseAssistant.WebApi.Repositories.Implementation
{
    public class StorageRepository : IStorageRepository
    {
        private readonly WarehouseDbContext _context;

        public StorageRepository(WarehouseDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Storage>> GetStoragesList()
        {
            return await _context.Storages.ToListAsync();
        }
    }
}
