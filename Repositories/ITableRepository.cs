using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ITableRepository
    {
        Task<Table> GetTable(int tableId);
        Task InsertTable(Table table);
        Task DeleteTable(Table table);
        Task UpdateTable(Table table);
        Task<IEnumerable<Table>> GetTables();
        Task UpdateTableStatus(int tableId, int status);
        Task<Table> CheckTableStatus(int tableId, int status);
    }
}
