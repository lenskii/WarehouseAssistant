using WarehouseAssistant.WebApi.Entities;

namespace WarehouseAssistant.WebApi.Repositories
{
    public interface IStorageRepository
    {
        Task<IEnumerable<Storage>> GetStoragesList();
    }
}
