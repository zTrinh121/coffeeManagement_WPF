using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public async Task DeleteAccount(Account account)
        {
            await AccountDAO.Instance.DeleteAccount(account);
        }

        public async Task<Account> GetAccount(int accountId)
        {
            return await AccountDAO.Instance.GetAccount(accountId);
        }

        public async Task<Account> GetAccountByUserName(string userName)
        {
            return await AccountDAO.Instance.GetAccountByUserName(userName);
        }

        public async Task<IEnumerable<Account>> GetAccounts()
        {
            return await AccountDAO.Instance.GetAccounts();
        }

        public async Task InsertAccount(Account account)
        {
            await AccountDAO.Instance.InsertAccount(account);
        }

        public async Task UpdateAccount(Account account)
        {
            await AccountDAO.Instance.UpdateAccount(account);
        }
    }
}
