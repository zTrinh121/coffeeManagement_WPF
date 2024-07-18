using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class BillInfoRepository : IBillInfoRepository
    {
        public async Task DeleteBillInfo(BillInfo billInfo)
        {
            await BillInfoDAO.Instance.DeleteBillInfo(billInfo);
        }

        public async Task<BillInfo> GetBillInfo(int billInfoId)
        {
            return await BillInfoDAO.Instance.GetBillInfo(billInfoId);
        }

        public async Task<IEnumerable<BillInfo>> GetBillInfos()
        {
            return await BillInfoDAO.Instance.GetBillInfos();
        }

        public async Task<IEnumerable<BillInfo>> GetBillInfosByBillId(int billId)
        {
            return await BillInfoDAO.Instance.GetBillInfosByBillId(billId);
        }

        public async Task<decimal> GetTotalBillOfATable(int billId)
        {
            return await BillInfoDAO.Instance.GetTotalBillOfATable(billId);
        }

        public async Task InsertBillInfo(BillInfo billInfo)
        {
            await BillInfoDAO.Instance.InsertBillInfo(billInfo);
        }

        public async Task UpdateBillInfo(BillInfo billInfo)
        {
            await BillInfoDAO.Instance.UpdateBillInfo(billInfo);
        }
    }
}
