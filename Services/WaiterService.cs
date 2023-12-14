using Cafe.Entities;
using Cafe.Models;
using System.Collections.Generic;
using System.Linq;

namespace Cafe.Services
{
    public class WaiterService
    {
        private readonly CafeDbContext _dbContext;

        public WaiterService()
        {
            _dbContext = new CafeDbContext();
        }

        public List<WaiterModel> GetAllWaiters() =>
             _dbContext.Waiters.Select(w => new WaiterModel
             {
                 Id = w.Id, 
                 Name = w.Name,
                 Surname = w.Surname,                 
            }).ToList();


        public bool DoesExist(int id) => _dbContext.Waiters.Any(mi => mi.Id == id);

        public void AddWaiterToDb(WaiterModel waiterModel)
        {
            var waiter = new Waiter
            {
                Id = waiterModel.Id,
                Name = waiterModel.Name,
                Surname = waiterModel.Surname
            };

            _dbContext.Waiters.Add(waiter);
            _dbContext.SaveChanges();   
        }

        public WaiterModel GetWaiterById(int id)
        {
            var dbWaiter = _dbContext.Waiters.FirstOrDefault(t => t.Id == id);
            if (dbWaiter == null)
            {
                return null;
            }

            return new WaiterModel { Id = dbWaiter.Id, Name = dbWaiter.Name, Surname = dbWaiter.Surname };
        }

        public void DeleteWaiterFromDb(int waiterId)
        {
            var waiterToRemove = _dbContext.Waiters.FirstOrDefault(item => item.Id == waiterId);

            if (waiterToRemove != null)
            {
                _dbContext.Waiters.Remove(waiterToRemove);
                _dbContext.SaveChanges();
            }
        }
    }
}
