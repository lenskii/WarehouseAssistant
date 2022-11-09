using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseAssistant.WebApi.Repositories;
using WarehouseAssistant.WebApi.Repositories.Implementation;

namespace WarehouseAssistant.WebApi.Logic.Commands.ItemMoves
{
    public class DeleteItemMoveCommandHandler : IRequestHandler<DeleteItemMoveCommand>
    {
        public IItemMoveRepository _itemMoveRepository { get; }
        public DeleteItemMoveCommandHandler(IItemMoveRepository itemMoveRepository)
        {
            _itemMoveRepository = itemMoveRepository;
        }

        public async Task<Unit> Handle(DeleteItemMoveCommand request, CancellationToken cancellationToken)
        {
            _itemMoveRepository.DeleteItemMoveByGuid(request.Guid);

            return Unit.Value;
       
        }
    }
}
