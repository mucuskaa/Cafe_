using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace Cafe.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public virtual Table? Table { get; set; }
        public virtual Waiter? Waiter { get; set; }

        public virtual ICollection<OrderPosition>? Positions { get; set; }

        public Order()
        {
            Positions = new List<OrderPosition>();  
        }
    }
}
