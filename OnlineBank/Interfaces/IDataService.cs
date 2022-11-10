//placeholder for method declaration, by default public and abstract
using OnlineBank.API.Models;

namespace OnlineBank.API.Interfaces
{
    public interface IDataService
    {
        public IUserRepository UsersDataObject { get; }
        public IAccountRepository AccountsDataObject { get; }
        public IAtmDetailsRepository AtmDetailsDataObject { get; }
        public IFundTransferRepository FundTransferDataObject { get; }
        public ITransactionRepository TransactionDataObject { get; }
        public IChequeBookRepo CheckBookDetailsDataObject { get; }
    
    }
}
