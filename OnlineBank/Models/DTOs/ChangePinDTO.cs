namespace OnlineBank.API.Models.DTOs
{
    public class ChangePinDTO
    {
        public long AccountNumber { get; set; }
        public int Pin { get; set; }
        public int NewPin { get; set; }


    }
}
