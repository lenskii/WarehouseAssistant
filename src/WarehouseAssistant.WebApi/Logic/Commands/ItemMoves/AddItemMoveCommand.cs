using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseAssistant.WebApi.Models.DTO;

namespace WarehouseAssistant.WebApi.Logic.Commands.ItemMoves
{
    public class AddItemMoveCommand : IRequest<Unit>{
        public ItemMoveDTO ItemMoveDto { get; }

        public AddItemMoveCommand(ItemMoveDTO itemMoveDto)
        {
            ItemMoveDto = itemMoveDto;
        }    
    }
}
