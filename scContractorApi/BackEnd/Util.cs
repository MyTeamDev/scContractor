using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scContractorApi.BackEnd
{
    public static class Util
    {
        public static string GenString(int length = 6)
        {
            Random random = new Random();
            string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(characters[random.Next(characters.Length)]);
            }
            return result.ToString();
        }

        internal static long GetCreateDate()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }
    }
}
