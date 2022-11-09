using System;

namespace OnlineBank.API.HelperTools
{
    //function used to generate a random account number upon the creation of a
    //new account. This Acc Number has 9 digits, and all numbers are within 1-9
    static class AccountNumberGenerator
    {
        public static string GenerateRandomAccountNumber()
        {
            Random random = new Random();

            string r = "";
            int i;

            for (i = 1; i < 11; i++)
            {
                r += random.Next(1, 9).ToString();
            }

            return r;
        }
    }
}

