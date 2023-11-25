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
                TableId = o.TableId,
                WaiterId = o.WaiterId
            }).ToList();
        }

        public List<OrderModel> GetOredersByDate(DateTime date)
        {
            var orders = _dbContext.Orders.Where(o=>o.Date.Date==date.Date).OrderByDescending(o=>o.Date);

            return orders.Select(o => new OrderModel
            {
                Date = o.Date,
                Id = o.Id,
                TableId = o.TableId,
                WaiterId = o.WaiterId
            }).ToList();
        }


    }
}
