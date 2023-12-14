using Cafe.Entities;
using Cafe.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cafe.Services
{
    public class OrderService
    {
        private readonly CafeDbContext _dbContext;
        public OrderService()
        {
            _dbContext = new CafeDbContext();
        }

        public List<OrderModel> GetAllOreders() =>
            _dbContext.Orders.Select(o => new OrderModel
            {
                Date = o.Date,
                Id = o.Id,
                Waiter = (o.Waiter == null) ? null : new WaiterModel
                {
                    Name = o.Waiter.Name,
                    Surname = o.Waiter.Surname,
                    
                },
                Table = (o.Table == null) ? null : new TableModel
                {
                    Id=o.Table.Id,
                    Status=o.Table.Status                 
                },

            }).ToList();

        public List<OrderModel> GetOredersByDate(DateTime date)
        {
            var orders = _dbContext.Orders
                .Include(o => o.Positions)
                .Where(o => o.Date.Date == date.Date)
                .OrderByDescending(o => o.Date);

            return orders.Select(o => new OrderModel
            {
                Date = o.Date,
                Id = o.Id,
                Waiter = (o.Waiter == null) ? null : new WaiterModel
                {
                    Name = o.Waiter.Name,
                    Surname = o.Waiter.Surname,

                },
                Table = (o.Table == null) ? null : new TableModel
                {
                    Id = o.Table.Id,
                    Status = o.Table.Status,

                },
                Positions = o.Positions.Select(p => new OrderPositionModel
                { 
                    MenuItem = new MenuItemModel
                    {
                        Id = p.MenuItem.Id,
                        Name = p.MenuItem.Name,
                        Price = p.MenuItem.Price,   
                    },
                    Quantity = p.Quantity,
                }).ToList()
            }).ToList();
        }

        public bool DoesExist(int id) => _dbContext.Orders.Any(mi => mi.Id == id);

        public void RemoveOrderFromDb(int orderId)
        {
            var orderToRemove = _dbContext.Orders.FirstOrDefault(item => item.Id == orderId);

            if (orderToRemove != null)
            {
                _dbContext.Orders.Remove(orderToRemove);
                _dbContext.SaveChanges();
            }
        }

        public void AddOrder(OrderModel order)
        {
            var table = _dbContext.Tables.Find(order.Table.Id);
            var waiter = _dbContext.Waiters.Find(order.Waiter.Id);

            var newOrder = new Order
            {
                Table = table,
                Waiter = waiter,
                Positions = order.Positions.Select(p => new OrderPosition 
                {
                    Status = p.Status,
                    Quantity = p.Quantity,
                    MenuItemId = p.MenuItem.Id
                }).ToList(),
            };

            _dbContext.Orders.Add(newOrder);

            _dbContext.SaveChanges();   
        }
    }
}
