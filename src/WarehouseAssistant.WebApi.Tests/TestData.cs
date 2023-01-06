using AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseAssistant.WebApi.Entities;

namespace WarehouseAssistant.WebApi.Tests
{
    public static class TestData
    {
        public static IEnumerable<Storage> Storages;
        public static IEnumerable<Transaction> Transactions;
        public static IEnumerable<Item> Items;
        public static IEnumerable<ItemMove> ItemMoves;

        public static void CreateTestData()
        {
            Storages = new List<Storage>()
            {
             new Storage
                {
                    Id = new Fixture().Create<int>(),
                    Name = new Fixture().Create<string>()
                },
                new Storage
                {
                    Id = new Fixture().Create<int>(),
                    Name = new Fixture().Create<string>()
                },
                new Storage
                {
                    Id = new Fixture().Create<int>(),
                    Name = new Fixture().Create<string>()
                }
            };

            Items = new List<Item>()
            {
                new Item
                {
                    Id = new Fixture().Create<int>(),
                    Name = new Fixture().Create<string>()
                },
                new Item
                {
                   Id = new Fixture().Create<int>(),
                    Name = new Fixture().Create<string>()
                },
                new Item
                {
                   Id = new Fixture().Create<int>(),
                    Name = new Fixture().Create<string>()
                },
                new Item
                {
                   Id = new Fixture().Create<int>(),
                    Name = new Fixture().Create<string>()
                },
                new Item
                {
                   Id = new Fixture().Create<int>(),
                    Name = new Fixture().Create<string>()
                },
                new Item
                {
                    Id = new Fixture().Create<int>(),
                    Name = new Fixture().Create<string>()
                },
                new Item
                {
                    Id = new Fixture().Create<int>(),
                    Name = new Fixture().Create<string>()
                }
            };

            var guidFrom1 = new Fixture().Create<Guid>();
            var guidFrom2 = new Fixture().Create<Guid>();
            var guidFrom3 = new Fixture().Create<Guid>();
            var guidTo1 = new Fixture().Create<Guid>();
            var guidTo2 = new Fixture().Create<Guid>();
            var guidTo3 = new Fixture().Create<Guid>();

            var itemCount1 = new Fixture().Create<int>();
            var itemCount2 = new Fixture().Create<int>();
            var itemCount3 = new Fixture().Create<int>();

            var storageFixture = new Fixture();
            storageFixture.Customizations.Add(new ElementsBuilder<int>(Storages.Select(s => s.Id)));

            int storageId1 = storageFixture.Create<int>();
            int storageId2 = storageFixture.Create<int>();
            int storageId3 = storageFixture.Create<int>();
            int storageId4 = storageFixture.Create<int>();

            var itemFixture = new Fixture();
            itemFixture.Customizations.Add(new ElementsBuilder<int>(Items.Select(s => s.Id)));

            int itemsId1 = itemFixture.Create<int>();
            int itemsId2 = itemFixture.Create<int>();
            int itemsId3 = itemFixture.Create<int>();
            int itemsId4 = itemFixture.Create<int>();

            var itemId1 = new Fixture();
            itemId1.Customizations.Add(new ElementsBuilder<int>(Items.Select(s => s.Id)));

            ItemMoves = new List<ItemMove>()
            {
                new ItemMove
                {
                        Guid = guidFrom1,
                        ItemsCount = -itemCount1,
                        StorageId =storageId1,
                        ItemId = itemsId1
                },
                new ItemMove
                {
                        Guid = guidTo1,
                        ItemsCount = itemCount1,
                        StorageId = storageId2,
                        ItemId = itemsId1
                },
                new ItemMove
                {
                        Guid = guidFrom2,
                        ItemsCount = -itemCount2,
                        StorageId = storageId2,
                        ItemId = itemsId2
                },
                new ItemMove
                {
                        Guid = guidTo2,
                        ItemsCount = itemCount2,
                        StorageId = storageId1,
                        ItemId = itemsId2
                },
                new ItemMove
                {
                        Guid = guidFrom3,
                        ItemsCount = -itemCount3,
                        StorageId = storageId1,
                        ItemId = itemsId3
                },
                new ItemMove
                {
                        Guid = guidTo3,
                        ItemsCount = itemCount3,
                        StorageId = storageId3,
                        ItemId = itemsId3
                }
            };

            Transactions = new List<Transaction>()
            {
                new Transaction
                {
                        Guid = new Fixture().Create<Guid>(),
                        DateTime = DateTime.Now.AddDays(-3),
                        ItemMoveFromGuid = guidFrom1,
                        ItemMoveToGuid = guidTo1,
                },
                new Transaction
                {
                        Guid = new Fixture().Create<Guid>(),
                        DateTime = DateTime.Now.AddDays(-2),
                        ItemMoveFromGuid = guidFrom2,
                        ItemMoveToGuid = guidTo2,
                },
                new Transaction
                {
                    Guid = new Fixture().Create<Guid>(),
                    DateTime = DateTime.Now.AddDays(-1),
                    ItemMoveFromGuid = guidFrom3,
                    ItemMoveToGuid = guidTo3,
                    },
            };
        }
    }
}
