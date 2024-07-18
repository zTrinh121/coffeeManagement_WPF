using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IAccountRepository
    {
        Task<Account> GetAccount(int accountId);
        Task InsertAccount(Account account);
        Task DeleteAccount(Account account);
        Task UpdateAccount(Account account);
        Task<IEnumerable<Account>> GetAccounts();
        Task<Account> GetAccountByUserName(string userName); 
    }
}
