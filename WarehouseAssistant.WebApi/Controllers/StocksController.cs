using MediatR;
using Microsoft.AspNetCore.Mvc;
using WarehouseAssistant.WebApi.Logic.Queries.Stocks;
using WarehouseAssistant.WebApi.Logic.Queries.Transactions;
using WarehouseAssistant.WebApi.Models.DTO;

namespace WarehouseAssistant.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StocksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StocksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{id}/{dateTime}")]
        public async Task<IEnumerable<ViewModels.GetStocksByGuidAndDateViewModel>> Index([FromRoute] int id, [FromRoute] string dateTime)
        {
            StockDTO stockDTO = new StockDTO() {
                StorageID = id, 
                StockDate = dateTime
            };

            return await _mediator.Send(new GetStocksByGuidAndDateQuery(stockDTO));
        }
    }
}
