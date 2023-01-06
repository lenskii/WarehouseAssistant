using MediatR;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseAssistant.WebApi.ViewModels;

namespace WarehouseAssistant.WebApi.Logic.Queries.Stocks
{
    public class GetStocksByGuidAndDateQuery : IRequest<IEnumerable<GetStocksByGuidAndDateViewModel>>
    {
        public DateTime StockDate { get; set; }
        public int StorageID { get; set; }

        CultureInfo provider = CultureInfo.InvariantCulture;
        public GetStocksByGuidAndDateQuery(Models.DTO.StockDTO stockDto)
        {
            StockDate = DateTime.ParseExact(stockDto.StockDate, "yyyy MM dd HH:mm:ss", provider);
            StorageID = stockDto.StorageID;
        }
    }
}
