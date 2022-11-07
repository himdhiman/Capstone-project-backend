using Microsoft.Extensions.Options;
using OnlineBank.API.Interfaces;
using OnlineBank.API.Models;
using OnlineBank.API.Repositories;

namespace OnlineBank.API.Services
{
    public class DataService : IDataService
    {
        private readonly MongoContext _dbContext;
        private readonly IOptions<MongoCollections> _mongoCollections;

        public DataService(MongoContext dbContext, IOptions<MongoCollections> mongoCollections)
        {
            _dbContext = dbContext;
            _mongoCollections = mongoCollections;
        }

        public IUserRepository UsersDataObject => new UserRepository(_dbContext.Database, _mongoCollections);
        public IRepository<Account> AccountsDataObject => new AccountRepository(_dbContext.Database, _mongoCollections);
        public IAtmDetailsRepository AtmDetailsDataObject => new AtmDetailsRepository(_dbContext.Database, _mongoCollections);
       
        public IFundTransferRepository FundTransferDataObject => new FundTransferRepository(_dbContext.Database, _mongoCollections);
        public ITransactionRepository TransactionDataObject => new TransactionRepository(_dbContext.Database, _mongoCollections);

        public IChequeBookRepo CheckBookDetailsDataObject => new ChequeBookDetailsRepository(_dbContext.Database, _mongoCollections);


    }
}
