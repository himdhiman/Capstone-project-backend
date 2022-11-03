using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OnlineBank.API.Models
{
    public class CheckBookDetails
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? CheckBookId { get; set; }
        public long AccountNumber { get; set; }
        public DateTime RequestedDate { get; set; }
        public DateTime IssueDate { get; set; }
        public int Priority { get; set; }
    }
}
