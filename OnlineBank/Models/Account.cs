using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OnlineBank.API.Models
{
    public class Account
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? AccountTypeId { get; set; }
        public string AccountType { get; set; } = null!;
    }
}
