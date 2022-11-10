using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

//Placeholder to define type of variables in respective class
namespace OnlineBank.API.Models
{
    public class Transaction
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? TransactionId { get; set; }
        public long AccountNumber { get; set; }
        public string AccountTypeId { get; set; } = null!;
        public string TransactionType { get; set; } = null!;
        public DateTime TransactionDate { get; set; }
        public float Amount { get; set; }
        public bool Credited { get; set; }
    }
}
