using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OnlineBank.API.Models;

namespace OnlineBank.API.Services
{
    public class MongoContext
    {
        private readonly MongoClient _client;
        private readonly IMongoDatabase _database;

        public MongoContext(IOptions<DatabaseSettings> databaseSettings)
        {
            _client = new MongoClient(databaseSettings.Value.ConnectionString);
            _database = _client.GetDatabase(databaseSettings.Value.DatabaseName);
        }

        public IMongoClient Client => _client;
        public IMongoDatabase Database => _database;
    }
}
