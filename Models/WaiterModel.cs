using System.Collections.Generic;

namespace Cafe.Models
{
    public class WaiterModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<OrderModel>? Orders { get; set; }
    }
}
