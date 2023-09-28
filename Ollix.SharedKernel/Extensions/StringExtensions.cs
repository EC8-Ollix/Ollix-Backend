using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.SharedKernel.Extensions
{
    public static class StringExtesions
    {
        public static string ToHash(this string input)
        {
            using SHA256 sha256 = SHA256.Create();

            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = sha256.ComputeHash(inputBytes);
            string hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

            return hash[..Math.Min(hash.Length, 60)];
        }

        public static bool ContainsUppercase(this string input)
        {
            return input.Any(char.IsUpper);
        }
        public static bool ContainsLowercase(this string input)
        {
            return input.Any(char.IsLower);
        }

        public static bool ContainsNumber(this string input)
        {
            return input.Any(char.IsDigit);
        }

        public static bool ContainsSpecialCharacter(this string input)
        {
            var specialCharacters = "!@#$%^&*()-_=+[{}];:'\",.<>/?";
            return input.Any(c => specialCharacters.Contains(c));
        }
    }
}
