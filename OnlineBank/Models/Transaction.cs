namespace OnlineBank.API.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public long AccountNumber { get; set; }
        public int AccountTypeId { get; set; }
        public string TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public float Amount { get; set; }
    }
}
