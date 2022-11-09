using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OnlineBank.API.Interfaces;
using OnlineBank.API.Models;

namespace OnlineBank.API.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IMongoCollection<Transaction> _transaction;

        public TransactionRepository(IMongoDatabase database, IOptions<MongoCollections> mongoCollections)
        {
            _transaction = database.GetCollection<Transaction>(mongoCollections.Value.TransactionsCollection);
        }

        public async Task<List<Transaction>> GetAsync() =>
            await _transaction.Find(_ => true).ToListAsync();

        public async Task<List<Transaction>> GetAsync(long accno) =>
            await _transaction.Find(x => x.AccountNumber == accno).ToListAsync();

        public async Task<Transaction?> GetAsync(string id) =>
            await _transaction.Find(x => x.TransactionId == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Transaction newTransaction) =>
            await _transaction.InsertOneAsync(newTransaction);

        public async Task UpdateAsync(string id, Transaction updatedTransaction) =>
            await _transaction.ReplaceOneAsync(x => x.TransactionId == id, updatedTransaction);

        public async Task RemoveAsync(string id) => await _transaction.DeleteOneAsync(x => x.TransactionId == id);
    }
}
