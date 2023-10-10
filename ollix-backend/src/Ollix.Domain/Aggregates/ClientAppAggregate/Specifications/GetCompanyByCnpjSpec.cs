using Ardalis.Specification;
using Ollix.Domain.ValueObjects;

namespace Ollix.Domain.Aggregates.ClientAppAggregate.Specifications
{
    public class GetCompanyByCnpjSpec : SingleResultSpecification<ClientApp>
    {
        public GetCompanyByCnpjSpec(CNPJ cnpj)
        {
            Query.Where(u => u.Cnpj!.Value == cnpj.Value);
        }
    }
}
