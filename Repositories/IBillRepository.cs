using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IBillRepository
    {
        Task<Bill> GetBill(int billId);
        Task InsertBill(Bill bill);
        Task DeleteBill(Bill bill);
        Task UpdateBill(Bill bill);
        Task<IEnumerable<Bill>> GetBills();
        Task<Bill> GetBillTableStatusPaid(int tableId, int status);
    }
}
