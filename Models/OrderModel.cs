using System;
using System.Collections.Generic;

namespace Cafe.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        public TableModel? Table { get; set; }

        public WaiterModel? Waiter { get; set; }

        public List<OrderPositionModel>? Positions { get; set; }  
    }
}
