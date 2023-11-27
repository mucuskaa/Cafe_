using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Entities
{
    public class OrderPosition
    {
        public int OrderId { get; set; }
     
        public int MenuItemId { get; set; }

        [Required]
        public int Quantity { get; set; }

        public virtual Order? Order { get; set; }

    }
}
