using Ollix.Domain.ValueObjects;
using Ollix.SharedKernel;

namespace Ollix.Domain.Aggregates.ClientAppAggregate
{
    public class ClientApp : EntityBase
    {
        public string? CompanyName { get; set; }
        public string? BussinessName { get; set; }
        public CNPJ? Cnpj { get; set; }
    }
}
