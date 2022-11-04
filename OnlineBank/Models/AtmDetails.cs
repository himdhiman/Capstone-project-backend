using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OnlineBank.API.Models
{
    public class AtmDetails
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public long AccountNumber { get; set; }
        public int AtmPin { get; set; }
        public float AccountBalance { get; set; }
    }
}
