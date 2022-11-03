namespace OnlineBank.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public long AccountNumber { get; set; }
        public string Name { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string[] SecurityQuestions { get; set; }
        public string[] SecurityAnswers { get; set; }
        public int AccountTypeId { get; set; }
        public string MobileNumber { get; set; }
    }
}
