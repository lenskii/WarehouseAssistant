using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAssistant.WebApi.Logic.Commands.Transactions
{ 
    public class DeleteTransactionCommand : IRequest
    {
        public Guid Guid { get; private set; }

        public DeleteTransactionCommand(Guid guid)
        {
            Guid = guid;
        }

        public DeleteTransactionCommand(string guid)
        {
            Guid = new Guid(guid);
        }
    }
}
