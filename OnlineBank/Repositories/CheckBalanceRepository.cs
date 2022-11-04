using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OnlineBank.API.Interfaces;
using OnlineBank.API.Models;

namespace OnlineBank.API.Repositories
{

    public class CheckBalanceRepository : IAccountBalance<AtmDetails>
    {
        private readonly IMongoCollection<AtmDetails> _atmDetails;

        public CheckBalanceRepository(IMongoDatabase database, IOptions<MongoCollections> mongoCollections)
        {
            _atmDetails = database.GetCollection<AtmDetails>(mongoCollections.Value.AtmDetailsCollection);
        }

        public async Task<AtmDetails?> GetAsync(long acnt) =>
           await _atmDetails.Find(x => x.AccountNumber == acnt).FirstOrDefaultAsync();



    }
}
