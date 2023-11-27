using Cafe.Models;
using Cafe.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MenuItem = Cafe.Entities.MenuItem;

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
                Id = i.Id,
                Name = i.Name,
                Price = i.Price

            }).ToList();
        }

        public void AddItemtoDb(MenuItemModel menuItemModel)
        {
            var menuItem = new MenuItem
            {
                Name = menuItemModel.Name,
                Price = menuItemModel.Price
            };

            _dbContext.MenuItems.Add(menuItem);

            _dbContext.SaveChanges();
        }

        public void DeleteItemFromDn(int itemId)
        {
            var itemToRemove = _dbContext.MenuItems.FirstOrDefault(item => item.Id == itemId);

            if (itemToRemove != null)
            {
                _dbContext.MenuItems.Remove(itemToRemove);
                _dbContext.SaveChanges();
            }
        }
    }
}
