using System;

namespace OnlineBank.API.HelperTools
{
    public class AccountNumberGenerator
    {
        public string acc()
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

