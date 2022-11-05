namespace OnlineBank.API.Models.DTOs
{
    public class FundTransferDTO
    {
        public long SourceAccountNumber { get; set; }
        public long destinationAccountNumber { get; set; }
        public float TransferAmount { get; set; }
    }
}
