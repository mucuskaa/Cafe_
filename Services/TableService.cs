using Cafe.Entities;
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
                Order = t.Order == null ? null : new OrderModel
                {
                    Id = t.Order.Id,
                    Date = t.Order.Date,

                },
                Waiter = t.Waiter == null ? null : new WaiterModel
                {
                    Name = t.Waiter.Name,
                    Surname = t.Waiter.Surname,
                },
                Status = t.Status,
            }).ToList();

        }

        public List<TableModel> GetAllTablesWithWaiters()
        {
            var tablesWithWaiters = _dbContext.Tables.Include(t => t.Waiter).Include(t => t.Order).ToList();


            return tablesWithWaiters.Select(t => new TableModel
            {
                Id = t.Id,
                Status = t.Status,
                Order = t.Order == null ? null : new OrderModel
                {
                    Id = t.Order.Id,
                    Date = t.Order.Date,

                },
                Waiter = t.Waiter == null ? null : new WaiterModel
                {
                    Name = t.Waiter.Name,
                    Surname = t.Waiter.Surname,
                },

            }).ToList();
        }

        public void AddTableToDb(TableModel tableModel)
        {
            var table = new Table
            {
                Id = tableModel.Id,
                Status = tableModel.Status,
                Order=null,
                Waiter=null,

            };

            _dbContext.Tables.Add(table);
            _dbContext.SaveChanges();
        }

        public void DeleteTableFromDb(int tableId)
        {
            var tableToRemove = _dbContext.Tables.FirstOrDefault(item => item.Id == tableId);

            if (tableToRemove != null)
            {
                _dbContext.Tables.Remove(tableToRemove);
                _dbContext.SaveChanges();
            }
        }
    }
}
