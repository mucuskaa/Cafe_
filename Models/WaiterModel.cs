using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Models
{
    public class WaiterModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int TableId { get; set; }

        //public Table Table { get; set; }
        //public ICollection<Order>? Orders { get; set; }
    }
}
