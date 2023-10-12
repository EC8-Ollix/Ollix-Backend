using Ollix.Domain.ValueObjects;
using Ollix.SharedKernel;

namespace Ollix.Domain.Aggregates.ClientAppAggregate
{
    public class ClientApp : EntityBase
    {
        public string? CompanyName { get; private set; }
        public string? BussinessName { get; private set; }
        public CNPJ? Cnpj { get; private set; }

        public ClientApp() { }

        public ClientApp(string companyName, string bussinessname, CNPJ cnpj)
        {
            CompanyName = companyName;
            BussinessName = bussinessname;
            Cnpj = cnpj;
        }

        public void SetCompanyName(string? companyName)
        {
            if (string.IsNullOrEmpty(companyName)) return;

            this.CompanyName = companyName;
        }

        public void SetBussinessName(string? bussinessName)
        {
            if (string.IsNullOrEmpty(bussinessName)) return;

            this.BussinessName = bussinessName;
        }
    }
}
