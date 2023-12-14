using Cafe.Common;
using Microsoft.EntityFrameworkCore;

namespace Cafe.Entities
{
    [PrimaryKey(nameof(OrderId), nameof(MenuItemId))]
    public class OrderPosition
    {
        public int OrderId { get; set; }
        public int MenuItemId { get; set; }

        public virtual Order? Order { get; set; }

        public virtual MenuItem? MenuItem { get; set; }

        public int Quantity { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.Ordered;
    }
}
