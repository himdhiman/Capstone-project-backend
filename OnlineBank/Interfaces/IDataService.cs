using OnlineBank.API.Models;

namespace OnlineBank.API.Interfaces
{
    public interface IDataService
    {
        public IRepository<User> UsersDataObject { get; }
        public IRepository<Account> AccountsDataObject { get; }
        public IRepository<AtmDetails> AtmDetailsDataObject { get; }

        public IAccountBalance<AtmDetails> BalanceDetailsObject { get; }

    }
}
