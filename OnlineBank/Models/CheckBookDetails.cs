namespace OnlineBank.API.Models
{
    public class CheckBookDetails
    {
        public int CheckBookId { get; set; }
        public long AccountNumber { get; set; }
        public DateTime RequestedDate { get; set; }
        public DateTime IssueDate { get; set; }
        public int Priority { get; set; }

    }
}
