namespace OnlineBank.API.Models
{
    public class CheckBookDetails
    {
        public int CheckBookId { set; get; }
        public long AccountNumber { set; get; }
        public DateTime RequestedDate { set; get; }
        public DateTime IssueDate { set; get; }
        public int Priority { set; get; }

    }
}
