using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace MeiredQuotes.Common.CS
{
    public static class StringExtensions
    {
        public static string ToSHA256(this String s)
        {
            using (SHA256 hash = SHA256Managed.Create())
            {
                return string.Join("", hash
                    .ComputeHash(Encoding.UTF8.GetBytes(s))
                    .Select(item => item.ToString("x2")));
            }
        }
    }
}
