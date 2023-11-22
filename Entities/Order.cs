using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
        public int TableId { get; set; }
        public int WaiterId { get; set; }

        public virtual Table Table { get; set; }

        public virtual Waiter Waiter { get; set; }
    }
}
