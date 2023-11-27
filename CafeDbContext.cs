using Cafe.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public class CafeDbContext : DbContext
    {
        public CafeDbContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderPosition> OrderPositions { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Waiter> Waiters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=CafeDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderPosition>().HasKey(x => new { x.OrderId, x.MenuItemId });
        
            modelBuilder.Entity<Table>()
                .HasOne(e => e.Order)
            .WithOne(e => e.Table)
                .HasForeignKey<Order>(e => e.TableId)
                .IsRequired(false);

            modelBuilder.Entity<Table>()
                .HasOne(e => e.Waiter)
            .WithOne(e => e.Table)
                .HasForeignKey<Waiter>(e => e.TableId)
                .IsRequired(false);
        
            base.OnModelCreating(modelBuilder);

            //var table1 = new Table
            //{
            //    Status = "Empty"

            //};

            //var waiter1=new Waiter
            //{
            //    Name = "Tom",
            //    Surname = "White"
            //};

            //waiter1.Table = table1;

            //Waiters.Add(waiter1);

            //SaveChanges();
        }

    }
}
