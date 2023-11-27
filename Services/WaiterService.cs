using Cafe.Entities;
using Cafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Services
{
    public class WaiterService
    {
        private readonly CafeDbContext _dbContext;

        public WaiterService()
        {
            _dbContext = new CafeDbContext();
        }

        public List<WaiterModel> GetAllWaiters()
        {
            var waiters = _dbContext.Waiters;

            return waiters.Select(w => new WaiterModel
            {
                Name = w.Name,
                Surname = w.Surname,
                Table = w.Table == null ? null : new TableModel
                {
                    Id = w.Table.Id,
                    Status = w.Table.Status,

                },
            }).ToList();
        }

        public void AddWaiterToDb(WaiterModel waiterModel)
        {
            var waiter = new Waiter
            {
                Id=waiterModel.Id,
                Name=waiterModel.Name,
                Surname=waiterModel.Surname,
                TableId=waiterModel.Table.Id
            };

            _dbContext.Waiters.Add(waiter);
            _dbContext.SaveChanges();   
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
