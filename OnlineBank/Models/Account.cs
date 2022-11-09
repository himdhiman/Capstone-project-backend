using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
//Placeholder to define type of variables
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
