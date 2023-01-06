using MediatR;
using Microsoft.AspNetCore.Mvc;
using WarehouseAssistant.WebApi.Entities;
using WarehouseAssistant.WebApi.Logic.Commands.Transactions;
using WarehouseAssistant.WebApi.Logic.Queries.Transactions;
using WarehouseAssistant.WebApi.Repositories;
using WarehouseAssistant.WebApi.Repositories.Implementation;

namespace WarehouseAssistant.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<ViewModels.GetTransactionsViewModel>> Index()
        {
            return await _mediator.Send(new GetTransactionsQuery());
        }

        [HttpPost]
        [Route($"{nameof(Add)}")]
        public async void Add([FromForm] Models.DTO.TransactionDTO transactionDto)
        {
            await _mediator.Send(new AddTransactionCommand(transactionDto));
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async void Delete([FromRoute] string id)
        {          
            await _mediator.Send(new DeleteTransactionCommand(id));     
        }
    }
}
