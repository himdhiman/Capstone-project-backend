using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OnlineBank.API.Interfaces;
using OnlineBank.API.Models;

namespace OnlineBank.API.Repositories
{
    public class CheckBookDetailsRepository : IRepository<CheckBookDetails>
    {
        private readonly IMongoCollection<CheckBookDetails> _checkBookDetails;

        public CheckBookDetailsRepository(IMongoDatabase database, IOptions<MongoCollections> mongoCollections)
        {
            _checkBookDetails = database.GetCollection<CheckBookDetails>(mongoCollections.Value.CheckBookDetailsCollection);
        }

        public async Task<List<CheckBookDetails>> GetAsync() =>
            await _checkBookDetails.Find(_ => true).ToListAsync();

        public async Task<CheckBookDetails?> GetAsync(string id) =>
            await _checkBookDetails.Find(x => x.CheckBookId == id).FirstOrDefaultAsync();

        public async Task CreateAsync(CheckBookDetails newCheckBook) =>
            await _checkBookDetails.InsertOneAsync(newCheckBook);

        public async Task UpdateAsync(string id, CheckBookDetails updatedCheckBookDetails) =>
            await _checkBookDetails.ReplaceOneAsync(x => x.CheckBookId == id, updatedCheckBookDetails);

        public async Task RemoveAsync(string id) => await _checkBookDetails.DeleteOneAsync(x => x.CheckBookId == id);
    }
}
