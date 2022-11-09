using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WarehouseAssistant.WebApi.DBContext;
using WarehouseAssistant.WebApi.Entities;


namespace WarehouseAssistant.WebApi.Repositories.Implementation
{
    public class ItemRepository : IItemRepository
    {
        private readonly WarehouseDbContext _context;

        public ItemRepository(WarehouseDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Item>> GetItemsList()
        {
            return await _context.Items.ToListAsync();
        }
    }
}
