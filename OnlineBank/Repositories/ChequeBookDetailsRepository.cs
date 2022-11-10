using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OnlineBank.API.Interfaces;
using OnlineBank.API.Models;

//Defining the methods as declared in respective Interfaces
namespace OnlineBank.API.Repositories
{
    public class ChequeBookDetailsRepository :IChequeBookRepo
    {
        private readonly IMongoCollection<ChequeBookDetails> _chequeBook;

        public ChequeBookDetailsRepository(IMongoDatabase database, IOptions<MongoCollections> mongoCollections)
        {
            _chequeBook = database.GetCollection<ChequeBookDetails>(mongoCollections.Value.CheckBookDetailsCollection);
        }

        public async Task<List<ChequeBookDetails>> GetAsync() =>
            await _chequeBook.Find(_ => true).ToListAsync();

        public async Task<ChequeBookDetails?> GetAsync(string id) =>
            await _chequeBook.Find(x => x.CheckBookId == id).FirstOrDefaultAsync();

        public async Task<ChequeBookDetails?> GetAsync(long AccountNumber) =>
       await _chequeBook.Find(x => x.AccountNumber == AccountNumber).FirstOrDefaultAsync();

        public async Task CreateAsync(ChequeBookDetails newCheckBook) =>
            await _chequeBook.InsertOneAsync(newCheckBook);

        public async Task UpdateAsync(string id, ChequeBookDetails updatedCheckBookDetails) =>
            await _chequeBook.ReplaceOneAsync(x => x.CheckBookId == id, updatedCheckBookDetails);

        public async Task RemoveAsync(string id) => await _chequeBook.DeleteOneAsync(x => x.CheckBookId == id);
    }
}
