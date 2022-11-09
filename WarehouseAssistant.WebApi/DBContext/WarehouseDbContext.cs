using Microsoft.EntityFrameworkCore;
using WarehouseAssistant.WebApi.Entities;

namespace WarehouseAssistant.WebApi.DBContext
{
    public class WarehouseDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<ItemMove> ItemMoves { get; set; }

        public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            CreateTestData(ref builder);

            builder.Entity<Storage>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Name).IsUnique();
                entity.Property(e => e.Name).IsRequired();
            });

            builder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Name).IsUnique();
                entity.Property(e => e.Name).IsRequired();
            });

            builder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.Guid);
            });

            builder.Entity<ItemMove>(entity =>
            {
                entity.HasKey(e => e.Guid);
            });
        }

        private void CreateTestData(ref ModelBuilder builder)
        {
            var guidFrom1 = Guid.NewGuid();
            var guidFrom2 = Guid.NewGuid();
            var guidFrom3 = Guid.NewGuid();
            var guidTo1 = Guid.NewGuid();
            var guidTo2 = Guid.NewGuid();
            var guidTo3 = Guid.NewGuid();
            
            builder.Entity<Storage>().HasData(
            new Storage[]
            {
                new Storage
                {
                    Id = 1,
                    Name = "Склад #1"
                },
                new Storage
                {
                    Id = 2,
                    Name = "Склад #2"
                },
                new Storage
                {
                    Id = 3,
                    Name = "Склад #3"
                }
            });

            builder.Entity<Item>().HasData(
            new Item[]
            {
                new Item
                {
                    Id = 1,
                    Name = "Номенклатура А"
                },
                new Item
                {
                    Id = 2,
                    Name = "Номенклатура Б"
                },
                new Item
                {
                    Id = 3,
                    Name = "Номенклатура В"
                },
                new Item
                {
                    Id = 4,
                    Name = "Номенклатура Г"
                },
                new Item
                {
                    Id = 5,
                    Name = "Номенклатура Д"
                },
                new Item
                {
                    Id = 6,
                    Name = "Номенклатура Е"
                },
                new Item
                {
                    Id = 7,
                    Name = "Номенклатура Ж"
                },
            });

            builder.Entity<Transaction>().HasData(
                new Transaction[]
                {
                    new Transaction
                    {
                        Guid = Guid.NewGuid(),
                        DateTime = DateTime.Now.AddDays(-3),
                        ItemMoveFromGuid = guidFrom1,
                        ItemMoveToGuid = guidTo1,                  
                    },
                    new Transaction
                    {
                        Guid = Guid.NewGuid(),
                        DateTime = DateTime.Now.AddDays(-2),
                        ItemMoveFromGuid = guidFrom2,
                        ItemMoveToGuid = guidTo2,
                    },
                    new Transaction
                    {
                        Guid = Guid.NewGuid(),
                        DateTime = DateTime.Now.AddDays(-1),
                        ItemMoveFromGuid = guidFrom3,
                        ItemMoveToGuid = guidTo3,
                    },
                });

            builder.Entity<ItemMove>().HasData(
                new ItemMove[]
                {
                    new ItemMove
                    {
                        Guid = guidFrom1,
                        ItemsCount = -40,
                        StorageId = 1,
                        ItemId = 1
                    },
                new ItemMove
                {
                        Guid = guidTo1,
                        ItemsCount = 40,
                        StorageId = 2,
                        ItemId = 1
                },
                new ItemMove
                {
                        Guid = guidFrom2,
                        ItemsCount = -30,
                        StorageId = 2,
                        ItemId = 2
                },
                new ItemMove
                {
                        Guid = guidTo2,
                        ItemsCount = 30,
                        StorageId = 1,
                        ItemId = 2
                },
                new ItemMove
                {
                        Guid = guidFrom3,
                        ItemsCount = -20,
                        StorageId = 1,
                        ItemId = 3
                },
                new ItemMove
                {
                        Guid = guidTo3,
                        ItemsCount = 20,
                        StorageId = 3,
                        ItemId = 3
                }
                });


        }
    }
}
