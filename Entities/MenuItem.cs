using System.ComponentModel.DataAnnotations;

namespace Cafe.Entities
{
    public class MenuItem
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public double Price { get; set; }

        public bool IsAvailiable { get; set; } = true;
    }
}
