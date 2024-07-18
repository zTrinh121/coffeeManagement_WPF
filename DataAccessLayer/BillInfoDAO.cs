using BusinessObjects;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class BillInfoDAO : SingletonBase<BillInfoDAO>
    {
        public async Task<BillInfo> GetBillInfo(int billInfoId)
        {
            BillInfo billInfo;
            try
            {
                billInfo = await _context.BillInfos.Include(x => x.IdBillNavigation).Include(x => x.IdDrinkNavigation).SingleOrDefaultAsync(x => x.BillInfoId == billInfoId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return billInfo;
        }

        public async Task<IEnumerable<BillInfo>> GetBillInfosByBillId(int billId)
        {
            List<BillInfo> billInfos;
            try
            {
                billInfos = await _context.BillInfos.Include(x => x.IdBillNavigation).Include(x => x.IdDrinkNavigation).Where(x => x.IdBill == billId).ToListAsync();
                //billInfos = await _context.BillInfos.Where(x => x.IdBill == billId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return billInfos;
        }

        public async Task InsertBillInfo(BillInfo billInfo)
        {
            try
            {
                _context.BillInfos.Add(billInfo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<BillInfo>> GetBillInfos()
        {
            List<BillInfo> billInfos;
            try
            {
                billInfos = await _context.BillInfos.Include(x => x.IdBillNavigation).Include(x => x.IdDrinkNavigation).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return billInfos;
        }

        public async Task UpdateBillInfo(BillInfo billInfo)
        {
            try
            {
                _context.BillInfos.Update(billInfo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteBillInfo(BillInfo billInfo)
        {
            try
            {
                _context.BillInfos.Remove(billInfo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Decimal> GetTotalBillOfATable(int billId)
        {
            try
            {
                return await _context.BillInfos.Include(x => x.IdBillNavigation).Include(x => x.IdDrinkNavigation).Where(x => x.IdBill == billId).SumAsync(x => x.IdDrinkNavigation.Price*x.Count);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}
