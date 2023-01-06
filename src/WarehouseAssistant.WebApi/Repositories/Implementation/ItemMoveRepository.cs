using Microsoft.EntityFrameworkCore;
using WarehouseAssistant.WebApi.DBContext;
using WarehouseAssistant.WebApi.Entities;

namespace WarehouseAssistant.WebApi.Repositories.Implementation
{
    public class ItemMoveRepository : IItemMoveRepository
    {
        private readonly WarehouseDbContext _context;

        public ItemMoveRepository(WarehouseDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ItemMove>> GetItemMovesList()
        {
           return await _context.ItemMoves.ToListAsync();
        }

        public async void AddItemMove(ItemMove itemMove)
        { 
            await _context.ItemMoves.AddAsync(itemMove);

            _context.SaveChanges();
        }

        public async void DeleteItemMoveByGuid(Guid itemMoveGuid)
        {
            ItemMove itemMove = _context.ItemMoves.FirstOrDefault(im => im.Guid == itemMoveGuid) ?? throw new KeyNotFoundException();

            _context.ItemMoves.Remove(itemMove);

            _context.SaveChanges();
        }
    }
}
