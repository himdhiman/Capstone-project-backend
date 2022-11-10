using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OnlineBank.API.Interfaces;
using OnlineBank.API.Models;

//Defining the methods as declared in respective Interfaces
namespace OnlineBank.API.Repositories
{
    public class AtmDetailsRepository : IAtmDetailsRepository
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

        public async Task<AtmDetails?> GetAsync(long AccountNumber) =>
            await _atmDetails.Find(x => x.AccountNumber == AccountNumber).FirstOrDefaultAsync();

        public async Task<AtmDetails?> GetAsync(int old_pin, long AccountNum) =>
            await _atmDetails.Find(x => x.AccountNumber == AccountNum && x.AtmPin == old_pin).FirstOrDefaultAsync();

        public async Task CreateAsync(AtmDetails newDetails) =>
            await _atmDetails.InsertOneAsync(newDetails);

        public async Task UpdateAsync(string id, AtmDetails updatedDetails) =>
            await _atmDetails.ReplaceOneAsync(x => x.Id == id, updatedDetails);

        public async Task UpdateAsync(long acnt_num, int pin)
        {
            var update = Builders<AtmDetails>.Update.Set(c => c.AtmPin, pin);
            await _atmDetails.FindOneAndUpdateAsync(x => x.AccountNumber == acnt_num, update) ;
        }

        public async Task RemoveAsync(string id) => await _atmDetails.DeleteOneAsync(x => x.Id == id);
    }
}
