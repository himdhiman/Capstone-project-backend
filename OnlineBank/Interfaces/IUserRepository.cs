using OnlineBank.API.Models;

namespace OnlineBank.API.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetAsyncByUsername(string username);
        Task<User?> GetAsyncByAccountNumber(long AccountNumber);
        Task UpdateBalance(long AccountNumber, float Amount);
    }
}
