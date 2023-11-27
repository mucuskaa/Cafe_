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
                TableId=w.TableId
            }).ToList();
        }
    }
}
