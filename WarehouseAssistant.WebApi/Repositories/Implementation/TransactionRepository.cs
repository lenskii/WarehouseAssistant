using Microsoft.EntityFrameworkCore;
using WarehouseAssistant.WebApi.DBContext;
using WarehouseAssistant.WebApi.Entities;

namespace WarehouseAssistant.WebApi.Repositories.Implementation
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly WarehouseDbContext _context;

        public TransactionRepository(WarehouseDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsList()
        {
            return await _context.Transactions.ToListAsync();
        }

        public Transaction GetTransactionByGuid(Guid transactionGuid)
        {
            return _context.Transactions.FirstOrDefault(t => t.Guid == transactionGuid) ?? throw new KeyNotFoundException();
        }

        public async void AddNewTransaction(Transaction transaction)
        { 
            await _context.Transactions.AddAsync(transaction);

            _context.SaveChanges();

        }

        public void DeleteTransactionByGuid(Guid transactionGuid)
        {
            _context.Transactions.Remove(GetTransactionByGuid(transactionGuid));

            _context.SaveChanges();
        }
    }
}
