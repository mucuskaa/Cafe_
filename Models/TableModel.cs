
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Models
{
    public class TableModel
    {
        public int Id { get; set; }
        public string Status { get; set; }

        public WaiterModel? Waiter { get; set; }

        public OrderModel? Order { get; set; }
    }
}
