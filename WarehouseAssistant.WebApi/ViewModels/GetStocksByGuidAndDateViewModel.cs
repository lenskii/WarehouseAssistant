using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAssistant.WebApi.ViewModels
{
    public class GetStocksByGuidAndDateViewModel
    {
        public string ItemName { get; set; }

        public int ItemsCount { get; set; }
    }   
}
