using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using OnlineBank.API.Validators;

//Placeholder to define type of variables in respective class
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

        //[UsernameValidator]
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string SecurityQuestion { get; set; } = null!;
        public string SecurityAnswers { get; set; } = null!;
        public string AccountTypeId { get; set; } = null!;
        public string MobileNumber { get; set; } = null!;
        public float AccountBalance { get; set; }
    }
}
