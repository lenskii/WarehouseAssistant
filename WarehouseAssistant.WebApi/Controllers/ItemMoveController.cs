using MediatR;
using Microsoft.AspNetCore.Mvc;
using WarehouseAssistant.WebApi.Logic.Commands.ItemMoves;
using WarehouseAssistant.WebApi.Logic.Commands.Transactions;
using WarehouseAssistant.WebApi.Logic.Queries.Transactions;

namespace WarehouseAssistant.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemMoveController : Controller
    {
        private readonly IMediator _mediator;

        public ItemMoveController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route($"{nameof(Add)}")]
        public void Add([FromForm] Models.DTO.ItemMoveDTO itemMoveDto)
        {
            _mediator.Send(new AddItemMoveCommand(itemMoveDto));
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async void Delete([FromRoute] string id)
        {
            await _mediator.Send(new DeleteItemMoveCommand(id));
        }
    }
}
