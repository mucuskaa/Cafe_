using Cafe.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        public TableModel? Table { get; set; }

        public WaiterModel? Waiter { get; set; }
    }
}
