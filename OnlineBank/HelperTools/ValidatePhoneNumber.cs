using System;
using System.Text.RegularExpressions;
namespace OnlineBank.API.HelperTools
{
    public class ValidatePhoneNumber
    {
        //this function will validate the input phone number using Regular expressions
        public bool _numIsValid = false;
        public const string motif = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";

        public ValidatePhoneNumber(string phNum)
        {
            if (phNum!=null) _numIsValid= Regex.IsMatch(phNum, motif);
        }
    }
}

