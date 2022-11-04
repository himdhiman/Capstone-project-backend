using OnlineBank.API.Models;

namespace OnlineBank.API.Interfaces
{
    public interface IAtmDetailsRepository : IRepository<AtmDetails>
    {
        Task<AtmDetails?> GetAsync(long AccountNumber);
    }
}
