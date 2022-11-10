using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
//Placeholder to define type of variables in respective class
namespace OnlineBank.API.Models
{
    public class AtmDetails
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public long AccountNumber { get; set; }
        public int AtmPin { get; set; }
    }
}
