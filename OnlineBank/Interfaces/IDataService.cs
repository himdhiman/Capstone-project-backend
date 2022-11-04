using OnlineBank.API.Models;

namespace OnlineBank.API.Interfaces
{
    public interface IDataService
    {
        public IRepository<User> Users { get; }
    }
}
