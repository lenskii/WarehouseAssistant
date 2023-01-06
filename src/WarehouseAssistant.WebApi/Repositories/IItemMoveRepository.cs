using WarehouseAssistant.WebApi.Entities;

namespace WarehouseAssistant.WebApi.Repositories
{
    public interface IItemMoveRepository
    {
        public Task<IEnumerable<ItemMove>> GetItemMovesList();

        public void AddItemMove(ItemMove itemMove);

        public void DeleteItemMoveByGuid(Guid itemMoveGuid);
    }
}
