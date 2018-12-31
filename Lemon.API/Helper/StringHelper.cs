using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lemon.API.Helper
{
    public sealed class StringHelper
    {
        static Random rnd = new Random();

        public static string GetRandomString(int length)
        {
            char[] code = "abcdefghjklmnpqrstuvwxyz23456789".ToCharArray();

            char[] result = new char[length];

            for (var i = 0; i < length; i++)
            {
                var chr = code[rnd.Next(code.Length)];
                result[i] = chr;
            }

            return new string(result);
        }
    }
}
