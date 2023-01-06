using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAssistant.WebApi.Logic.Commands.ItemMoves
{
    public class DeleteItemMoveCommand : IRequest
    {
        public Guid Guid { get; private set; }

        public DeleteItemMoveCommand(Guid guid)
        {
            Guid = guid;
        }

        public DeleteItemMoveCommand(string guid)
        {
            Guid = new Guid(guid);
        }
    }
}
