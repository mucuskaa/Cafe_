using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Entities
{
    public class Waiter
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        public int? TableId { get; set; }
        public virtual Table? Table { get; set; }   
        public virtual ICollection<Order>? Orders { get; set; }
    }
}
