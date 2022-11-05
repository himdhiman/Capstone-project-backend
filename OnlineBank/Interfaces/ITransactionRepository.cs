using OnlineBank.API.Models;

namespace OnlineBank.API.Interfaces
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        Task<List<Transaction>> GetAsync(long accno);
    }
}
