using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseAssistant.WebApi.Repositories;
using Moq;
using Microsoft.AspNetCore.Mvc;
using WarehouseAssistant.WebApi.Entities;
using WarehouseAssistant.WebApi.Logic.Queries.Stocks;
using WarehouseAssistant.WebApi.Repositories.Implementation;
using Microsoft.EntityFrameworkCore;
using WarehouseAssistant.WebApi.Models.DTO;
using AutoFixture;

namespace WarehouseAssistant.WebApi.Tests.Logic.Queries.Stocks
{
    public class GetStocksByGuidAndDateQueryTests
    {
        private Mock<ITransactionRepository> _transactionRepositoryMock;
        private Mock<IItemRepository> _itemRepositoryMock;
        private Mock<IStorageRepository> _storageRepositoryMock;
        private Mock<IItemMoveRepository> _itemMoveRepositoryMock;

        public GetStocksByGuidAndDateQueryTests()
        {
            _transactionRepositoryMock = new Mock<ITransactionRepository>();
            _itemRepositoryMock = new Mock<IItemRepository>();
            _storageRepositoryMock = new Mock<IStorageRepository>();
            _itemMoveRepositoryMock = new Mock<IItemMoveRepository>();
        }

        [Fact]
        public async void GetStocksByGuidAndDateQuery_NotNull()
        {
            // Arrange
            SetupMocks();

            var storageFixture = new Fixture();
            storageFixture.Customizations.Add(new ElementsBuilder<int>(TestData.Storages.Select(s => s.Id)));

            int storageId = storageFixture.Create<int>();
      
            StockDTO dto = new StockDTO()
            {
                StockDate = DateTime.Now.ToString("yyyy MM dd HH:mm:ss"),
                StorageID = storageId
            };

            GetStocksByGuidAndDateQuery query = new GetStocksByGuidAndDateQuery(dto);

            GetStocksByGuidAndDateQueryHandler getStocksByGuidAndDateQueryHandler =
                new GetStocksByGuidAndDateQueryHandler(
                    _transactionRepositoryMock.Object,
                    _itemRepositoryMock.Object,
                    _storageRepositoryMock.Object,
                    _itemMoveRepositoryMock.Object
                );

            // Act
            var result = await getStocksByGuidAndDateQueryHandler.Handle(query, new CancellationToken());

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async void GetStocksByGuidAndDateQuery_GetZeroByDate()
        {
            // Arrange
            SetupMocks();

            var storageFixture = new Fixture();
            storageFixture.Customizations.Add(new ElementsBuilder<int>(TestData.Storages.Select(s => s.Id)));

            int storageId = storageFixture.Create<int>();


            StockDTO dto = new StockDTO()
            {
                StockDate = DateTime.MinValue.ToString("yyyy MM dd HH:mm:ss"),
                StorageID = storageId
            };

            GetStocksByGuidAndDateQuery query = new GetStocksByGuidAndDateQuery(dto);

            GetStocksByGuidAndDateQueryHandler inventoryItemService =
                new GetStocksByGuidAndDateQueryHandler(
                    _transactionRepositoryMock.Object,
                    _itemRepositoryMock.Object,
                    _storageRepositoryMock.Object,
                    _itemMoveRepositoryMock.Object
                );

            // Act
            var result = await inventoryItemService.Handle(query, new CancellationToken());

            // Assert        
            Assert.True(result.Count() == 0);
        }

        [Fact]
        public async void GetStocksByGuidAndDateQuery_GetZeroByStorageId()
        {
            // Arrange
            SetupMocks();

            StockDTO dto = new StockDTO()
            {
                StockDate = DateTime.Now.ToString("yyyy MM dd HH:mm:ss"),
                StorageID = 0
            };

            GetStocksByGuidAndDateQuery query = new GetStocksByGuidAndDateQuery(dto);

            GetStocksByGuidAndDateQueryHandler inventoryItemService =
                new GetStocksByGuidAndDateQueryHandler(
                    _transactionRepositoryMock.Object,
                    _itemRepositoryMock.Object,
                    _storageRepositoryMock.Object,
                    _itemMoveRepositoryMock.Object
                );

            // Act
            var result = await inventoryItemService.Handle(query, new CancellationToken());

            // Assert        
            Assert.True(result.Count() == 0);
        }


        private void SetupMocks()
        {
            TestData.CreateTestData();

            _transactionRepositoryMock.Setup(repo => repo.GetTransactionsList()).ReturnsAsync(TestData.Transactions);
            _itemRepositoryMock.Setup(repo => repo.GetItemsList()).ReturnsAsync(TestData.Items);
            _storageRepositoryMock.Setup(repo => repo.GetStoragesList()).ReturnsAsync(TestData.Storages);
            _itemMoveRepositoryMock.Setup(repo => repo.GetItemMovesList()).ReturnsAsync(TestData.ItemMoves);
        }
    }
}
