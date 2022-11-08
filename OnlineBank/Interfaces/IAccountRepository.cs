using OnlineBank.API.Models;

namespace OnlineBank.API.Interfaces
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<Account> GetAsyncByName(string name);
    }
}
