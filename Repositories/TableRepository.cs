using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class TableRepository : ITableRepository
    {
        public async Task<Table> CheckTableStatus(int tableId, int status)
        {
            return await TableDAO.Instance.CheckTableStatus(tableId, status);
        }

        public async Task DeleteTable(Table table)
        {
            await TableDAO.Instance.DeleteTable(table);
        }

        public async Task<Table> GetTable(int tableId)
        {
            return await TableDAO.Instance.GetTable(tableId);
        }

        public async Task<IEnumerable<Table>> GetTables()
        {
            return await TableDAO.Instance.GetTables();
        }

        public async Task InsertTable(Table table)
        {
            await TableDAO.Instance.InsertTable(table);
        }

        public async Task UpdateTable(Table table)
        {
            await TableDAO.Instance.UpdateTableFood(table);
        }

        public async Task UpdateTableStatus(int tableId, int status)
        {
            await TableDAO.Instance.UpdateTableStatus(tableId, status);
        }
    }
}
