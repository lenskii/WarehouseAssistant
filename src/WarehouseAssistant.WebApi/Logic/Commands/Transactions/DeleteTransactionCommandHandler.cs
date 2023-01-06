using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseAssistant.WebApi.Repositories;
using WarehouseAssistant.WebApi.Repositories.Implementation;
using Microsoft.EntityFrameworkCore;
using WarehouseAssistant.WebApi.Logic.Commands.ItemMoves;

namespace WarehouseAssistant.WebApi.Logic.Commands.Transactions
{
    public class DeleteTransactionCommandHandler : IRequestHandler<DeleteTransactionCommand>
    {
        public IMediator _mediator { get; }
        public ITransactionRepository _transactionRepository { get; }
        public IItemMoveRepository _itemMoveRepository { get; }

        public DeleteTransactionCommandHandler(IMediator mediator, ITransactionRepository transactionRepository, IItemMoveRepository itemMoveRepository)
        {
            _mediator = mediator;
            _transactionRepository = transactionRepository;
            _itemMoveRepository = itemMoveRepository;
        }

        public async Task<Unit> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {
            Entities.Transaction transaction = _transactionRepository.GetTransactionByGuid(request.Guid);

            _transactionRepository.DeleteTransactionByGuid(request.Guid);

            await _mediator.Send(new DeleteItemMoveCommand(transaction.ItemMoveFromGuid));
            await _mediator.Send(new DeleteItemMoveCommand(transaction.ItemMoveToGuid));

            return Unit.Value;
        }
    }
}
