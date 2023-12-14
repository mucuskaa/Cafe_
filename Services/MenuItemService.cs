using Cafe.Entities;
using Cafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cafe.Services
{
    public class MenuItemService
    {
        private readonly CafeDbContext _dbContext;
        public MenuItemService()
        {
            _dbContext = new CafeDbContext();
        }

        public List<MenuItemModel> GetAllMenuItems() =>
            _dbContext.MenuItems.Select(i => new MenuItemModel
            {
                Id = i.Id,
                Name = i.Name,
                Price = i.Price

            }).ToList();

        public void AddItemToDb(MenuItemModel menuItemModel)
        {
            var menuItem = new MenuItem
            {
                Name = menuItemModel.Name,
                Price = menuItemModel.Price
            };

            _dbContext.MenuItems.Add(menuItem);
            _dbContext.SaveChanges();
        }

        public bool DoesExist(int id) => _dbContext.MenuItems.Any(mi => mi.Id == id);

        public void RemoveMenuItemFromDb(int itemId)
        {
            var itemToRemove = _dbContext.MenuItems.FirstOrDefault(item => item.Id == itemId);

            if (itemToRemove != null)
            {
                _dbContext.MenuItems.Remove(itemToRemove);
                _dbContext.SaveChanges();
            }
        }       

        public MenuItemModel GetDishById(int id)
        {
            var menuItem = _dbContext.MenuItems.FirstOrDefault(mi => mi.Id == id);

            if (menuItem != null)
                return null;

            return new MenuItemModel { Id = id, Name = menuItem.Name, Price = menuItem.Price };
        }

        public List<MenuItemModel> GetAllAvailiableMenuItems() =>
         _dbContext.MenuItems.Where(i => i.IsAvailiable).Select(i => new MenuItemModel
         {
             Id = i.Id,
             Name = i.Name,
             Price = i.Price

         }).ToList();
    }
}
