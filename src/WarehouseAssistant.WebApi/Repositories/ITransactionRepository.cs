using WarehouseAssistant.WebApi.Entities;

namespace WarehouseAssistant.WebApi.Repositories
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> GetTransactionsList();

        public Transaction GetTransactionByGuid(Guid transactionGuid);

        void AddNewTransaction(Transaction transaction);

        void DeleteTransactionByGuid(Guid transactionGuid);


    }
}
