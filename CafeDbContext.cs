using Cafe.Common;
using Cafe.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cafe
{
    public class CafeDbContext : DbContext
    {
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderPosition> OrderPositions { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Waiter> Waiters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=CafeDB;Trusted_Connection=True;TrustServerCertificate=true;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var menu1 = new MenuItem
            {
                Id = 1,
                Name = "Barbequ",
                Price = 22.5
            };

            var menu2 = new MenuItem
            {
                Id = 2,
                Name = "Hinkali",
                Price = 45
            };

            var menu3 = new MenuItem
            {
                Id = 3,
                Name = "Soup Harcho",
                Price = 11.4
            };

            modelBuilder.Entity<MenuItem>().HasData(menu1, menu2, menu3);

            var table1 = new Table
            {
                Id = 1,
                Status = TableStatus.Empty
            };

            var table2 = new Table
            {
                Id = 2,
                Status = TableStatus.Empty
            };

            var table3 = new Table
            {
                Id = 3,
                Status = TableStatus.Empty
            };

            modelBuilder.Entity<Table>().HasData(table1, table2, table3);


            var waiter1 = new Waiter
            {
                Id = 1,
                Name = "Tom",
                Surname = "White"
            };

            var waiter2 = new Waiter
            {
                Id = 2,
                Name = "Bob",
                Surname = "Jenkins"
            };

            modelBuilder.Entity<Waiter>().HasData(waiter1, waiter2);
        }
    }
}
