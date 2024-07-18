using BusinessObjects;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace DataAccessLayer
{
    public class TableDAO : SingletonBase<TableDAO>
    {
        public async Task<Table> GetTable(int tableId)
        {
            Table tableFood;
            try
            {
                tableFood = await _context.Tables.SingleOrDefaultAsync(x => x.TableId == tableId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return tableFood;
        }

        public async Task InsertTable(Table table)
        {
            try
            {
                _context.Tables.Add(table);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Table>> GetTables()
        {
            List<Table> tables;
            try
            {
                tables = await _context.Tables.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return tables;
        }

        public async Task UpdateTableFood(Table table)
        {
            try
            {
                _context.Tables.Update(table);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateTableStatus(int tableId, int status)
        {
            try
            {
                string newStatus = status == 0 ? "Có người" : "Trống";
                await _context.Database.ExecuteSqlRawAsync(
                    "UPDATE [dbo].[Table] SET TableStatus = {0} WHERE TableId = {1}",
                    newStatus, tableId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating table status: {ex.Message}");
            }
        }


        public async Task DeleteTable(Table table)
        {
            try
            {
                _context.Tables.Remove(table);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Table> CheckTableStatus(int tableId, int status)
        {
            string statusTable = "";
            if(status == 0) statusTable = "Có người";
            else statusTable = "Trống";
            Table table;
            try
            {
                table = await _context.Tables.Where(x => x.TableId == tableId && x.TableStatus == statusTable).FirstOrDefaultAsync();
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return table;
        }
    }

}
