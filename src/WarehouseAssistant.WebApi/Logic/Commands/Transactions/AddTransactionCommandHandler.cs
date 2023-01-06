using MediatR;
using System.ComponentModel.DataAnnotations;
using WarehouseAssistant.WebApi.Models.DTO;
using WarehouseAssistant.WebApi.Repositories;

namespace WarehouseAssistant.WebApi.Logic.Commands.Transactions
{
    public class AddTransactionCommandHandler : IRequestHandler<AddTransactionCommand, Unit>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IItemMoveRepository _itemMoveRepository;

        public AddTransactionCommandHandler(ITransactionRepository transactionRepository, IItemMoveRepository itemMoveRepository)
        {
            _transactionRepository = transactionRepository;
            _itemMoveRepository = itemMoveRepository;
        }

        public Task<Unit> Handle(AddTransactionCommand request, CancellationToken cancellationToken)
        {
            Entities.ItemMove itemMoveFrom = CreateItemMoveFrom(request.TransactionDto);
            Entities.ItemMove itemMoveTo = CreateItemMoveTo(request.TransactionDto);
            Entities.Transaction transaction = CreateTransaction(itemMoveFrom, itemMoveTo);

            _transactionRepository.AddNewTransaction(transaction);
            _itemMoveRepository.AddItemMove(itemMoveFrom);
            _itemMoveRepository.AddItemMove(itemMoveTo);

            return Task.FromResult(Unit.Value);
        }

        private Entities.Transaction CreateTransaction(Entities.ItemMove itemMoveFrom, Entities.ItemMove itemMoveTo)
        {
            return new Entities.Transaction()
            {
                DateTime = DateTime.Now,
                Guid = Guid.NewGuid(),
                ItemMoveFromGuid = itemMoveFrom.Guid,
                ItemMoveToGuid = itemMoveTo.Guid
            };

        }

        private Entities.ItemMove CreateItemMoveFrom(TransactionDTO transactionDto)
        {
            return new Entities.ItemMove()
            {
                Guid = Guid.NewGuid(),
                ItemId = transactionDto.ItemId,
                ItemsCount = -transactionDto.ItemsCount,
                StorageId = transactionDto.StorageFromId
            };
        }

        private Entities.ItemMove CreateItemMoveTo(TransactionDTO transactionDto)
        {
            return new Entities.ItemMove()
            {
                Guid = Guid.NewGuid(),
                ItemId = transactionDto.ItemId,
                ItemsCount = transactionDto.ItemsCount,
                StorageId = transactionDto.StorageToId
            };
        }
    }

}
