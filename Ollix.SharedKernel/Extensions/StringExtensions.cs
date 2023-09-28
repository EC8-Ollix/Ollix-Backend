using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
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

        public static bool IsValidCnpj(this string cnpj)
        {
            cnpj = Regex.Replace(cnpj, @"[^\d]", "");

            if (cnpj.Length != 14)
                return false;

            if (cnpj.All(digit => digit == cnpj[0]))
                return false;

            int[] multiplicador1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma = 0;
            for (int i = 0; i < 12; i++)
                soma += (cnpj[i] - '0') * multiplicador1[i];
            int resto = soma % 11;
            int digito1 = resto < 2 ? 0 : 11 - resto;


            int[] multiplicador2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            soma = 0;
            cnpj += digito1.ToString();
            for (int i = 0; i < 13; i++)
                soma += (cnpj[i] - '0') * multiplicador2[i];
            resto = soma % 11;
            int digito2 = resto < 2 ? 0 : 11 - resto;

            return cnpj[12] - '0' == digito1 && cnpj[13] - '0' == digito2;
        }
    }
}
