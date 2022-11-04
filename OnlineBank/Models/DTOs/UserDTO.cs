namespace OnlineBank.API.Models.DTOs
{
    public class UserDTO
    {
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
