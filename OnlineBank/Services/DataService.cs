﻿using Microsoft.Extensions.Options;
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

        public IRepository<User> Users => new UserRepository(_dbContext.Database, _mongoCollections);
        public IRepository<Account> Accounts => new AccountRepository(_dbContext.Database, _mongoCollections);

    }
}
