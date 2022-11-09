using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
//Placeholder to define type of variables in respective class
namespace OnlineBank.API.Models
{
    public class ChequeBookDetails
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
