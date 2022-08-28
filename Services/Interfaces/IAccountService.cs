using TestbART.Model;

namespace TestbART.Services.Interfaces
{
    public interface IAccountService
    {
        Task CreateAccountAsync(Account account);

        Task UpdateAccountAsync(int id, Account account);

        List<Account> GetAllAccounts();
    }
}
