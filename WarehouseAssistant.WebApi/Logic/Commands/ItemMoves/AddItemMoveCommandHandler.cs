using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseAssistant.WebApi.Models.DTO;
using WarehouseAssistant.WebApi.Repositories;

namespace WarehouseAssistant.WebApi.Logic.Commands.ItemMoves
{
    public class AddItemMoveCommandHandler : IRequestHandler<AddItemMoveCommand>
    {

        private readonly IItemMoveRepository _itemMoveRepository;

        public AddItemMoveCommandHandler(IItemMoveRepository itemMoveRepository)
        {
            _itemMoveRepository = itemMoveRepository;
        }
        
        public Task<Unit> Handle(AddItemMoveCommand request, CancellationToken cancellationToken)
        {
            _itemMoveRepository.AddItemMove(MapToEF(request.ItemMoveDto));

            return Task.FromResult(Unit.Value);
        }

        private Entities.ItemMove MapToEF(ItemMoveDTO itemMoveDto)
        {
            return new Entities.ItemMove()
            {
                Guid = Guid.NewGuid(),
                ItemId = itemMoveDto.ItemId,
                ItemsCount = itemMoveDto.ItemsCount,
                StorageId = itemMoveDto.StorageId

            };
        }
    }
}
