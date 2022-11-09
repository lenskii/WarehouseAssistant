using WarehouseAssistant.WebApi.Entities;

namespace WarehouseAssistant.WebApi.Repositories
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetItemsList();
    }
}
