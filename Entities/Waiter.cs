using System.Collections.Generic;

namespace Cafe.Entities
{
    public class Waiter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<Order>? Orders { get; set; }

        public Waiter()
        {
            Orders = new List<Order>(); 
        }
    }
}
