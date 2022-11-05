using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OnlineBank.API.Interfaces;
using OnlineBank.API.Models;

namespace OnlineBank.API.Repositories
{
    public class FundTransferRepository : IFundTransferRepository
    {
        private readonly IMongoCollection<FundTransfer> _fundTransfer;

        public FundTransferRepository(IMongoDatabase database, IOptions<MongoCollections> mongoCollections)
        {
            _fundTransfer = database.GetCollection<FundTransfer>(mongoCollections.Value.FundTransfersCollection);
        }

        public async Task<List<FundTransfer>> GetAsync() =>
            await _fundTransfer.Find(_ => true).ToListAsync();

        public async Task<FundTransfer?> GetAsync(string id) =>
            await _fundTransfer.Find(x => x.TransferId == id).FirstOrDefaultAsync();

        public async Task CreateAsync(FundTransfer newTransfer) =>
            await _fundTransfer.InsertOneAsync(newTransfer);

        public async Task UpdateAsync(string id, FundTransfer updatedFundDetails) =>
            await _fundTransfer.ReplaceOneAsync(x => x.TransferId == id, updatedFundDetails);

        public async Task RemoveAsync(string id) => await _fundTransfer.DeleteOneAsync(x => x.TransferId == id);
    }
}
