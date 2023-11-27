using Cafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Services
{
    public class OrderPositionService
    {
        private readonly CafeDbContext _dbContext;
        public OrderPositionService()
        {
            _dbContext = new CafeDbContext();
        }

        public List<OrderPositionModel> GetAllOrderPositions(int orderId)
        {
            var orderPositions = _dbContext.OrderPositions.Where(op => op.OrderId == orderId).OrderByDescending(op => op.OrderId);

            return orderPositions.Select(op => new OrderPositionModel
            {
                MenuItemId = op.MenuItemId,
                Order = op.Order == null ? null : new OrderModel
                {
                    Id = op.Order.Id,
                    Date = op.Order.Date,

                },
                Quantity = op.Quantity

            }).ToList();
        }
    }
}
