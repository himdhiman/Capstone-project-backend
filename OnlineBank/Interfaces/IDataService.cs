using OnlineBank.API.Models;

namespace OnlineBank.API.Interfaces
{
    public interface IDataService
    {
        public IUserRepository UsersDataObject { get; }
        public IRepository<Account> AccountsDataObject { get; }
        public IAtmDetailsRepository AtmDetailsDataObject { get; }
    }
}
