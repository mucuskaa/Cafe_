using Cafe.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Services
{
    public class TableService
    {
        private readonly CafeDbContext _dbContext;

        public TableService()
        {
            _dbContext = new CafeDbContext();
        }

        public List<TableModel> GetAllTables()
        {
            var tables = _dbContext.Tables;

            return tables.Select(t => new TableModel
            {
                Id = t.Id,
                OrderId = t.OrderId,
                Status = t.Status,
                WaiterId = t.WaiterId,
            }).ToList();
        }
    }
}
