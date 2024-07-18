using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class BillRepository : IBillRepository
    {
        public async Task DeleteBill(Bill bill)
        {
            await BillDAO.Instance.DeleteBill(bill);
        }

        public async Task<Bill> GetBill(int billId)
        {
            return await BillDAO.Instance.GetBill(billId);
        }

        public async Task<IEnumerable<Bill>> GetBills()
        {
            return await BillDAO.Instance.GetBills();
        }

        public async Task<Bill> GetBillTableStatusPaid(int tableId, int status)
        {
            return await BillDAO.Instance.GetBillTableStatusPaid(tableId, status);
        }

        public async Task InsertBill(Bill bill)
        {
            await BillDAO.Instance.InsertBill(bill);
        }

        public async Task UpdateBill(Bill bill)
        {
            await BillDAO.Instance.UpdateBill(bill);
        }
    }
}
