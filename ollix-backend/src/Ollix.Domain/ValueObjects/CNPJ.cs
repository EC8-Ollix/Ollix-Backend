using Ollix.SharedKernel;
using Ollix.SharedKernel.Extensions;
using System.Text.RegularExpressions;

namespace Ollix.Domain.ValueObjects
{
    public class CNPJ : ValueObject
    {
        public string? Value { get; set; }

        public CNPJ(string cnpj)
        {
            Value = FormatCnpj(cnpj);
        }

        public CNPJ() { }

        public override string ToString() => Value ?? string.Empty;

        private string FormatCnpj(string cnpj)
        {
            if (string.IsNullOrEmpty(cnpj) || !cnpj.IsValidCnpj())
                throw new Exception("Cnpj Inválido");

            cnpj = Regex.Replace(cnpj, @"[^\d]", "");
            return string.Format("{0:00\\.000\\.000\\/0000-00}", long.Parse(cnpj));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value ?? string.Empty;
        }
    }
}
