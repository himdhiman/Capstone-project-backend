using OnlineBank.API.Models;

namespace OnlineBank.API.Interfaces
{
    public interface IAtmDetailsRepository : IRepository<AtmDetails>
    {
        Task<AtmDetails?> GetAsync(long AccountNumber);

        Task UpdateAsync(long AccountNumber, int pin_num);

        Task<AtmDetails?> GetAsync(int old_pin,long AccountNumber);
    }
}