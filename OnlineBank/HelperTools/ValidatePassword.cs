using System;
namespace OnlineBank.API.HelperTools
{
    public class ValidatePassword
    {
        private bool _isValid = false;
        /*checks if Password:
            is Greater than 8 characters,
            is Less than 15 characters,
            does not contain an empty character,
            has atleast one lower character,
                            upper character,
                            special character,
                            digit.
        */
        public ValidatePassword(string pass)
        {
            if (!(pass.Length < 8) && !(pass.Length > 15) && pass.Any(char.IsUpper) && pass.Any(char.IsLower) && !pass.Contains(" ") && pass.Any(char.IsLetterOrDigit) && pass.Any(char.IsDigit))
            {
                _isValid = true;
            }
        }

        
    }
}

