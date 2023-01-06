using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseAssistant.WebApi.Entities;
using WarehouseAssistant.WebApi.Logic.Queries.Stocks;
using WarehouseAssistant.WebApi.Logic.Queries.Transactions;
using WarehouseAssistant.WebApi.Models.DTO;
using WarehouseAssistant.WebApi.Repositories;
using WarehouseAssistant.WebApi.Repositories.Implementation;

namespace WarehouseAssistant.WebApi.Tests.Logic.Queries.Transactions
{
    public class GetTransactionsQueryTests
    {
        private Mock<ITransactionRepository> _transactionRepositoryMock;
        private Mock<IItemRepository> _itemRepositoryMock;
        private Mock<IStorageRepository> _storageRepositoryMock;
        private Mock<IItemMoveRepository> _itemMoveRepositoryMock;

        public GetTransactionsQueryTests()
        {
            _transactionRepositoryMock = new Mock<ITransactionRepository>();
            _itemRepositoryMock = new Mock<IItemRepository>();
            _storageRepositoryMock = new Mock<IStorageRepository>();
            _itemMoveRepositoryMock = new Mock<IItemMoveRepository>();
        }

        [Fact]
        public void GetTransactionsQuery_NotNull()
        {
            // Arrange
            SetupMocks();

            GetTransactionsQuery query = new GetTransactionsQuery();

            GetTransactionsQueryHandler getTransactionsQueryHandler =
                new GetTransactionsQueryHandler(
                    _transactionRepositoryMock.Object,
                    _itemRepositoryMock.Object,
                    _storageRepositoryMock.Object,
                    _itemMoveRepositoryMock.Object
                );

            // Act
            var result = getTransactionsQueryHandler.Handle(query, new CancellationToken());

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async void GetTransactionsQuery_CorrectCount()
        {
            // Arrange
            SetupMocks();

            GetTransactionsQuery query = new GetTransactionsQuery();

            GetTransactionsQueryHandler getTransactionsQueryHandler =
                new GetTransactionsQueryHandler(
                    _transactionRepositoryMock.Object,
                    _itemRepositoryMock.Object,
                    _storageRepositoryMock.Object,
                    _itemMoveRepositoryMock.Object
                );

            // Act
            var result = await getTransactionsQueryHandler.Handle(query, new CancellationToken());

            // Assert
            Assert.True(result.Count() == TestData.Transactions.Count());
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
