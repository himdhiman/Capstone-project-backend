using OnlineBank.API.Interfaces;
using OnlineBank.API.Models;
using OnlineBank.API.Repositories;

namespace OnlineBank.API.Services
{
    public class DataService : IDataService
    {
        private readonly MongoContext _dbContext;

        public DataService(MongoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<User> Users => new UserRepository(_dbContext.Database);
    }
}
