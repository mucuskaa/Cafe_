using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Entities
{
    public class Table
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        public int? WaiterId { get; set; }

        public int? OrderId { get; set; }
        public virtual Waiter? Waiter { get; set; }

        public virtual Order? Order { get; set; }
    }

}
