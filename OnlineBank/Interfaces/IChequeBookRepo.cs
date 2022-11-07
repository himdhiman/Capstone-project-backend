using OnlineBank.API.Models;

namespace OnlineBank.API.Interfaces
{
    public interface IChequeBookRepo: IRepository<ChequeBookDetails>
    {
        Task<ChequeBookDetails?> GetAsync(long AccountNumber);
    }
}
