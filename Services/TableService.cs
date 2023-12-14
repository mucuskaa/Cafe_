using Cafe.Entities;
using Cafe.Models;
using System.Collections.Generic;
using System.Linq;

namespace Cafe.Services
{
    public class TableService
    {
        private readonly CafeDbContext _dbContext;

        public TableService()
        {
            _dbContext = new CafeDbContext();
        }

        public List<TableModel> GetAllTables() =>
            _dbContext.Tables.Select(t => new TableModel
            {
                Id = t.Id,               
                Status = t.Status,
            }).ToList();

        public void AddTableToDb(TableModel tableModel)
        {
            var table = new Table
            {
                Id = tableModel.Id,
                Status = tableModel.Status
            };

            _dbContext.Tables.Add(table);
            _dbContext.SaveChanges();
        }

        public TableModel GetTableById(int id)
        {
            var dbTable = _dbContext.Tables.FirstOrDefault(t => t.Id == id); 
            if (dbTable == null) 
            {
                return null;
            }

            return new TableModel { Id = dbTable.Id, Status = dbTable.Status }; 
        }

        public bool DoesExist(int id) => _dbContext.Tables.Any(mi => mi.Id == id);

        public void RemoveTableFromDb(int tableId)
        {
            var tableToRemove = _dbContext.Tables.Find(tableId);

            if (tableToRemove != null)
            {
                _dbContext.Tables.Remove(tableToRemove);
                _dbContext.SaveChanges();
            }
        }
    }
}
