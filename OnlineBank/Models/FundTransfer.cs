namespace OnlineBank.API.Models
{
    public class FundTransfer
    {
        public int TransferId { get; set; }
        public long SourceAccountNumber { get; set; }
        public long destinationAccountNumber { get; set; }
        public int DestinationAccountTypeId { get; set; }
        public float TransferAmount { get; set; }
    }
}
