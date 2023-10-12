using Ardalis.Specification;
using Ollix.Domain.ValueObjects;

namespace Ollix.Domain.Aggregates.ClientAppAggregate.Specifications
{
    public class ClientByCnpjSpec : SingleResultSpecification<ClientApp>
    {
        public ClientByCnpjSpec(CNPJ cnpj)
        {
            Query.Where(u => u.Cnpj!.Value == cnpj.Value);
        }
    }
}
