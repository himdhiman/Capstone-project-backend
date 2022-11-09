namespace OnlineBank.API.Models.DTOs
{
    public class UserReturnObject
    {
        public string Id { get; set; } = null!;
        public long AccountNumber { get; set; }
        public string Name { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string UserName { get; set; } = null!;
        public string SecurityQuestion { get; set; } = null!;
        public string SecurityAnswer { get; set; } = null!;
        public string AccountType { get; set; } = null!;
        public string MobileNumber { get; set; } = null!;
        public float AccountBalance { get; set; }
    }
}
