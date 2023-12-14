using Cafe.Common;

namespace Cafe.Models
{
    public class OrderPositionModel
    {
        public int Quantity { get; set; }
        public OrderStatus Status { get; set; }
        public OrderModel? Order { get; set; }
        public MenuItemModel? MenuItem { get; set; }    
    }
}
