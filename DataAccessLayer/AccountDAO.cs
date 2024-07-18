using BusinessObjects;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AccountDAO : SingletonBase<AccountDAO>
    {
        public async Task<Account> GetAccount(int accountId)
        {
            Account account;
            try
            {
                account = await _context.Accounts.SingleOrDefaultAsync(x => x.AccountId == accountId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return account;
        }

        public async Task<Account> GetAccountByUserName(string userName)
        {
            Account account;
            try
            {
                account = await _context.Accounts.SingleOrDefaultAsync(x => x.UserName == userName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return account;
        }

        public async Task InsertAccount(Account account)
        {
            try
            {
                _context.Accounts.Add(account);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Account>> GetAccounts()
        {
            List<Account> accounts;
            try
            {
                accounts = await _context.Accounts.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return accounts;
        }

        public async Task UpdateAccount(Account account)
        {
            try
            {
                _context.Accounts.Update(account);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteAccount(Account account)
        {
            try
            {
                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}
