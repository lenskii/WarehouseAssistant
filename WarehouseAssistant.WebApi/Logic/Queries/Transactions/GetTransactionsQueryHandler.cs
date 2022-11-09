using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Collections.Generic;
using WarehouseAssistant.WebApi.Entities;
using WarehouseAssistant.WebApi.Repositories;
using WarehouseAssistant.WebApi.Repositories.Implementation;

namespace WarehouseAssistant.WebApi.Logic.Queries.Transactions
{
    public class GetTransactionsQueryHandler : IRequestHandler<GetTransactionsQuery, IEnumerable<ViewModels.GetTransactionsViewModel>>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IStorageRepository _storageRepository;
        private readonly IItemMoveRepository _itemMoveRepository;

        public GetTransactionsQueryHandler(
            ITransactionRepository transactionRepository,
            IItemRepository itemRepository,
            IStorageRepository storageRepository,
            IItemMoveRepository itemMoveRepository)
        {
            _transactionRepository = transactionRepository;
            _itemRepository = itemRepository;
            _storageRepository = storageRepository;
            _itemMoveRepository = itemMoveRepository;
        }

        public async Task<IEnumerable<ViewModels.GetTransactionsViewModel>> Handle(GetTransactionsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Transaction> transactions = await _transactionRepository.GetTransactionsList();
            IEnumerable<Item> items = await _itemRepository.GetItemsList();
            IEnumerable<Storage> storages = await _storageRepository.GetStoragesList();
            IEnumerable<ItemMove> itemMoves = await _itemMoveRepository.GetItemMovesList();
            
            IEnumerable<ViewModels.GetTransactionsViewModel> query = from transaction in transactions
                                                        join itemMoveFrom in itemMoves on transaction.ItemMoveFromGuid equals itemMoveFrom.Guid
                                                        join itemMoveTo in itemMoves on transaction.ItemMoveToGuid equals itemMoveTo.Guid
                                                        join item in items on itemMoveTo.ItemId equals item.Id
                                                        join storageFrom in storages on itemMoveFrom.StorageId equals storageFrom.Id
                                                        join storageTo in storages on itemMoveTo.StorageId equals storageTo.Id
                                                        select new ViewModels.GetTransactionsViewModel
                                                        {
                                                            Guid = transaction.Guid,
                                                            ItemName = item.Name,
                                                            DateTime = transaction.DateTime,
                                                            StorageFromName = storageFrom.Name,
                                                            StorageInName = storageTo.Name,
                                                            ItemsCount = itemMoveTo.ItemsCount
                                                        };

            return query;
        }
    }
}


