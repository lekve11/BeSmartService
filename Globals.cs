using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BeSmartService
{
   public static class Globals
    {
        public static string GetSHA256(string userName, string password)
        {
            char[] charArr = userName.ToCharArray();

            Array.Reverse(charArr);

            SHA256Managed crypt = new SHA256Managed();
            string hash = String.Empty;
            password += new string(charArr);
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(password), 0, Encoding.ASCII.GetByteCount(password));
            foreach (byte theByte in crypto)
            {
                hash += theByte.ToString("x2");
            }
            return hash;
        }
    }
}
