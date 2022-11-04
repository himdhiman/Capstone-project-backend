using System;

namespace OnlineBank.API.HelperTools
{
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

