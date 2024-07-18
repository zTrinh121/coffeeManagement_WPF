using BusinessObjects;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BillDAO : SingletonBase<BillDAO>
    {
        public async Task<Bill> GetBill(int billId)
        {
            Bill bill;
            try
            {
                bill = await _context.Bills.Include(x => x.IdTableNavigation).Include(x => x.BillInfos).SingleOrDefaultAsync(x => x.BillId == billId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return bill;
        }

        public async Task<Bill> GetBillTableStatusPaid(int tableId, int status)
        {
            Bill bill;
            try
            {
                bill = await _context.Bills.Include(x => x.IdTableNavigation).Include(x => x.BillInfos).Where(x => x.IdTable == tableId && x.Status == status).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return bill;
        }

        public async Task InsertBill(Bill bill)
        {
            try
            {
                _context.Bills.Add(bill);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Bill>> GetBills()
        {
            List<Bill> bills;
            try
            {
                bills = await _context.Bills.Include(x => x.IdTableNavigation).Include(x => x.BillInfos).ToListAsync();
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return bills;
        }

        public async Task UpdateBill(Bill bill)
        {
            try
            {
                _context.Bills.Update(bill);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteBill(Bill bill)
        {
            try
            {
                _context.Bills.Remove(bill);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
       
    }

}
