using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseAssistant.WebApi.ViewModels;
using WarehouseAssistant.WebApi.Repositories;
using WarehouseAssistant.WebApi.Entities;
using WarehouseAssistant.WebApi.Models.DTO;

namespace WarehouseAssistant.WebApi.Logic.Queries.Stocks
{
    public class GetStocksByGuidAndDateQueryHandler : IRequestHandler<GetStocksByGuidAndDateQuery, IEnumerable<GetStocksByGuidAndDateViewModel>>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IStorageRepository _storageRepository;
        private readonly IItemMoveRepository _itemMoveRepository;

        public GetStocksByGuidAndDateQueryHandler(
             ITransactionRepository transactionRepository,
            IItemRepository itemRepository,
            IStorageRepository storageRepository,
            IItemMoveRepository itemMoveRepository
            )
        {
            _transactionRepository = transactionRepository;
            _itemRepository = itemRepository;
            _storageRepository = storageRepository;
            _itemMoveRepository = itemMoveRepository;
        }

        public async Task<IEnumerable<GetStocksByGuidAndDateViewModel>> Handle(GetStocksByGuidAndDateQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Transaction> transactions = await _transactionRepository.GetTransactionsList();
            IEnumerable<Item> items = await _itemRepository.GetItemsList();
            IEnumerable<Storage> storages = await _storageRepository.GetStoragesList();
            IEnumerable<ItemMove> itemMoves = await _itemMoveRepository.GetItemMovesList();

            var itemMovesDates = (from t in transactions 
                                  select new { DateTime = t.DateTime, ItemMoveGuid = t.ItemMoveFromGuid })
                                  .Concat(from t in transactions 
                                          select new { DateTime = t.DateTime, ItemMoveGuid = t.ItemMoveToGuid });

            IEnumerable<GetStocksByGuidAndDateViewModel> query = from itemMove in itemMoves
                                                                 where itemMove.StorageId == request.StorageID                                                        
                                                                 join itemMovesDate in itemMovesDates on itemMove.Guid equals itemMovesDate.ItemMoveGuid
                                                                 where itemMovesDate.DateTime <= request.StockDate
                                                                 join item in items on itemMove.ItemId equals item.Id
                                                                 group itemMove by new { itemMove.StorageId, item.Name } into stocksByGuidAndDate
                                                                 select new GetStocksByGuidAndDateViewModel
                                                                 {
                                                                     ItemName = stocksByGuidAndDate.Key.Name,
                                                                     ItemsCount = stocksByGuidAndDate.Sum(x=> x.ItemsCount),
                                                                 };
            return query;
        }
    }
}
