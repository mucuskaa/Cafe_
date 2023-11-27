using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cafe.Models;

namespace Cafe.Services
{
    public class OrderService
    {
        private readonly CafeDbContext _dbContext;
        public OrderService()
        {
            _dbContext = new CafeDbContext();
        }

        public List<OrderModel> GetAllOreders()
        {
            var orders = _dbContext.Orders;

            return orders.Select(o => new OrderModel
            {
                Date = o.Date,
                Id = o.Id,
                Waiter=o.Waiter == null ? null : new WaiterModel
                {
                    Name = o.Waiter.Name,
                    Surname = o.Waiter.Surname,
                    
                },
                Table=o.Table == null ? null : new TableModel
                {
                    Id=o.Table.Id,
                    Status=o.Table.Status,
                    
                },

            }).ToList();
        }

        public List<OrderModel> GetOredersByDate(DateTime date)
        {
            var orders = _dbContext.Orders.Where(o=>o.Date.Date==date.Date).OrderByDescending(o=>o.Date);

            return orders.Select(o => new OrderModel
            {
                Date = o.Date,
                Id = o.Id,
                Waiter = o.Waiter == null ? null : new WaiterModel
                {
                    Name = o.Waiter.Name,
                    Surname = o.Waiter.Surname,

                },
                Table = o.Table == null ? null : new TableModel
                {
                    Id = o.Table.Id,
                    Status = o.Table.Status,

                },
            }).ToList();
        }

        public void DeleteOrderFromDb(int orderId)
        {
            var orderToRemove = _dbContext.Orders.FirstOrDefault(item => item.Id == orderId);

            if (orderToRemove != null)
            {
                _dbContext.Orders.Remove(orderToRemove);
                _dbContext.SaveChanges();
            }
        }
    }
}
