using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ollix.Domain.Shared.ValueObjects
{
    public class CNPJ
    {
        private string? value;

        public string Value
        {
            get 
            { 
                return value ?? string.Empty; 
            }
            private set
            {
                if (IsValidCnpj(value))    
                    this.value = FormatCnpj(value);
                else             
                    throw new ArgumentException("Invalid CNPJ");               
            }
        }

        public CNPJ(string cnpj) => Value = cnpj;

        public override string ToString() => value ?? string.Empty;

        public static bool IsValidCnpj(string cnpj)
        {
            cnpj = Regex.Replace(cnpj, @"[^\d]", "");

            if (cnpj.Length != 14)
                return false;

            if (new string(cnpj[0], 14) == cnpj)
                return false;

            int[] multipliers1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multipliers2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int sum1 = 0;
            int sum2 = 0;

            for (int i = 0; i < 12; i++)
            {
                sum1 += int.Parse(cnpj[i].ToString()) * multipliers1[i];
                sum2 += int.Parse(cnpj[i].ToString()) * multipliers2[i];
            }

            int remainder1 = sum1 % 11 == 0 ? 0 : 11 - (sum1 % 11);
            int remainder2 = sum2 % 11 == 0 ? 0 : 11 - (sum2 % 11);

            return int.Parse(cnpj[12].ToString()) == remainder1 && int.Parse(cnpj[13].ToString()) == remainder2;
        }

        private string FormatCnpj(string cnpj)
        {
            cnpj = Regex.Replace(cnpj, @"[^\d]", "");
            return string.Format("{0:00\\.000\\.000\\/0000-00}", long.Parse(cnpj));
        }
    }
}
