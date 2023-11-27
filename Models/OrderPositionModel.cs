using Cafe.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Models
{
    public class OrderPositionModel
    {

        public int MenuItemId { get; set; }

        public int Quantity { get; set; }

        public OrderModel? Order { get; set; }
    }
}
