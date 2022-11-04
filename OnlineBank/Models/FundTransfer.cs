using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OnlineBank.API.Models
{
    public class FundTransfer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? TransferId { get; set; }
        public long SourceAccountNumber { get; set; }
        public long destinationAccountNumber { get; set; }
        public string DestinationAccountTypeId { get; set; } = null!;
        public float TransferAmount { get; set; }
    }
}
