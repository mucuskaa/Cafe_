using Cafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Services
{
    public class MenuItemService
    {
        private readonly CafeDbContext _dbContext;
        public MenuItemService()
        {
            _dbContext = new CafeDbContext();
        }

        public List<MenuItemModel> GetAllMenuItems()
        {
            var items = _dbContext.MenuItems;

            return items.Select(i => new MenuItemModel
            {
                Name = i.Name,
                Price=i.Price

            }).ToList();
        }
    }
}
