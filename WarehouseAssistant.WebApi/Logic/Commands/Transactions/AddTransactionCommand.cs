using MediatR;
using WarehouseAssistant.WebApi.Models.DTO;

namespace WarehouseAssistant.WebApi.Logic.Commands.Transactions
{
    public class AddTransactionCommand : IRequest<Unit>
    {
        public TransactionDTO TransactionDto { get; }

        public AddTransactionCommand(TransactionDTO transactionDto)
        {
            TransactionDto = transactionDto;
        }    
    }
}
