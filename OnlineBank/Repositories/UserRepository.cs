using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OnlineBank.API.Interfaces;
using OnlineBank.API.Models;

namespace OnlineBank.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _users;

        public UserRepository(IMongoDatabase database, IOptions<MongoCollections> mongoCollections)
        {
            _users = database.GetCollection<User>(mongoCollections.Value.UsersCollection);
        }

        public async Task<List<User>> GetAsync() =>
            await _users.Find(_ => true).ToListAsync();

        public async Task<User?> GetAsync(string id) =>
            await _users.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<User?> GetAsyncByUsername(string username) =>
            await _users.Find(x => x.UserName == username).FirstOrDefaultAsync();

        public async Task<User?> GetAsyncByAccountNumber(long accountNumber) =>
            await _users.Find(x => x.AccountNumber == accountNumber).FirstOrDefaultAsync();

        public async Task CreateAsync(User newUser) =>
            await _users.InsertOneAsync(newUser);

        public async Task UpdateAsync(string id, User updatedUser) =>
            await _users.ReplaceOneAsync(x => x.Id == id, updatedUser);

        public async Task UpdateBalance(long AccountNumber, float Amount)
        {
            var filter = new FilterDefinitionBuilder<User>().Where(x => x.AccountNumber == AccountNumber);
            var options = new FindOneAndUpdateOptions<User, User>();
            var update = Builders<User>.Update.Set(p => p.AccountBalance, Amount);
            await _users.UpdateOneAsync(filter, update);
        }

        public async Task RemoveAsync(string id) => await _users.DeleteOneAsync(x => x.Id == id);
    }
}
