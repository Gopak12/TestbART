using TestbART.Data;
using TestbART.Model;
using TestbART.Services.Interfaces;

namespace TestbART.Services
{
    public class AccountService : IAccountService
    {
        private readonly TestbARTContext _context;

        public AccountService(TestbARTContext context)
        {
            _context = context;
        }

        public async Task CreateAccountAsync(Account account)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAccountAsync(int id, Account account)
        {
            var accountToUpdate = _context.Accounts.FirstOrDefault(x => x.Id == id);
            if (accountToUpdate == null)
            {
                throw new ArgumentNullException(nameof(account));
            }
            accountToUpdate.Name = account.Name;
            accountToUpdate.Contacts = account.Contacts;

            _context.Update(accountToUpdate);
            await _context.SaveChangesAsync();
        }

        public List<Account> GetAllAccounts()
        {
            return _context.Accounts.ToList();
        }
    }
}
