using Ardalis.Specification;
using Ollix.Domain.ValueObjects;

namespace Ollix.Domain.Aggregates.ClientAppAggregate.Specifications
{
    public class GetClientByCnpjSpec : SingleResultSpecification<ClientApp>
    {
        public GetClientByCnpjSpec(CNPJ cnpj)
        {
            Query.Where(u => u.Cnpj!.Value == cnpj.Value);
        }
    }
}
