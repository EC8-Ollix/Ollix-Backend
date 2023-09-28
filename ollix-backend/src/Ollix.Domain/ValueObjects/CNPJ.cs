using Ollix.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ollix.Domain.ValueObjects
{
    public class CNPJ : ValueObject
    {
        public string? Value { get; set; }

        public CNPJ(string cnpj)
        {
            if (!IsValidCnpj(cnpj))
                throw new ArgumentException("Invalid CNPJ");

            Value = FormatCnpj(cnpj);
        }

        public CNPJ() { }

        public override string ToString() => Value ?? string.Empty;

        public static bool IsValidCnpj(string cnpj)
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

        private string FormatCnpj(string cnpj)
        {
            cnpj = Regex.Replace(cnpj, @"[^\d]", "");
            return string.Format("{0:00\\.000\\.000\\/0000-00}", long.Parse(cnpj));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
