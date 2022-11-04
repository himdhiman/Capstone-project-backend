using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace OnlineBank.API.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public long AccountNumber { get; set; }
        public string Name { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public List<string> SecurityQuestions { get; set; } = null!;
        public List<string> SecurityAnswers { get; set; } = null!;
        public string AccountTypeId { get; set; } = null!;
        public string MobileNumber { get; set; } = null!;
    }
}
