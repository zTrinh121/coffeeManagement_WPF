using BusinessObjects;

namespace Repositories
{
    public interface IBillInfoRepository
    {
        Task<BillInfo> GetBillInfo(int billInfoId);
        Task InsertBillInfo(BillInfo billInfo);
        Task DeleteBillInfo(BillInfo billInfo);
        Task UpdateBillInfo(BillInfo billInfo);
        Task<IEnumerable<BillInfo>> GetBillInfos();
        Task<IEnumerable<BillInfo>> GetBillInfosByBillId(int billId);
        Task<Decimal> GetTotalBillOfATable(int billId);
    }
}
