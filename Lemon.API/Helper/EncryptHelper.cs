using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemon.API.Helper
{
    public sealed class EncryptHelper
    {
        public static string MD5(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            byte[] data = Encoding.UTF8.GetBytes(input);
            var md5 = System.Security.Cryptography.MD5.Create();

            byte[] hashData = md5.ComputeHash(data);

            String result = BitConverter.ToString(hashData).Replace("-", "");
            return result;
        }
    }
}
