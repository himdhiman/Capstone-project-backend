namespace OnlineBank.API.Models
{
    public class FundTransfer
    {
        public int TransferId { set; get; }
        public long SourceAccountNumber { set; get; }
        public long destinationAccountNumber { set; get; }
        public int DestinationAccountTypeId { set; get; }
        public float TransferAmount { set; get; }
    }
}
