using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OnlineBank.API.Interfaces;
using OnlineBank.API.Models;

namespace OnlineBank.API.Repositories
{
    public class AccountRepository : IRepository<Account>
    {
        private readonly IMongoCollection<Account> _accounts;

        public AccountRepository(IMongoDatabase database, IOptions<MongoCollections> mongoCollections)
        {
            _accounts = database.GetCollection<Account>(mongoCollections.Value.AccountsCollection);
        }

        public async Task<List<Account>> GetAsync() =>
            await _accounts.Find(_ => true).ToListAsync();

        public async Task<Account?> GetAsync(string id) =>
            await _accounts.Find(x => x.AccountTypeId == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Account newAccount) =>
            await _accounts.InsertOneAsync(newAccount);

        public async Task UpdateAsync(string id, Account updatedAccount) =>
            await _accounts.ReplaceOneAsync(x => x.AccountTypeId == id, updatedAccount);

        public async Task RemoveAsync(string id) => await _accounts.DeleteOneAsync(x => x.AccountTypeId == id);
    }
}
