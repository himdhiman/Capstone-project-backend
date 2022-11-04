using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OnlineBank.API.Interfaces;
using OnlineBank.API.Models;

namespace OnlineBank.API.Repositories
{
    public class AtmDetailsRepository : IRepository<AtmDetails>
    {
        private readonly IMongoCollection<AtmDetails> _atmDetails;

        public AtmDetailsRepository(IMongoDatabase database, IOptions<MongoCollections> mongoCollections)
        {
            _atmDetails = database.GetCollection<AtmDetails>(mongoCollections.Value.AtmDetailsCollection);
        }

        public async Task<List<AtmDetails>> GetAsync() =>
            await _atmDetails.Find(_ => true).ToListAsync();

        public async Task<AtmDetails?> GetAsync(string id) =>
            await _atmDetails.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(AtmDetails newDeatils) =>
            await _atmDetails.InsertOneAsync(newDeatils);

        public async Task UpdateAsync(string id, AtmDetails updatedDetails) =>
            await _atmDetails.ReplaceOneAsync(x => x.Id == id, updatedDetails);

        public async Task RemoveAsync(string id) => await _atmDetails.DeleteOneAsync(x => x.Id == id);
    }
}
