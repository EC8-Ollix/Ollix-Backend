using Ardalis.Specification;
using Ollix.Domain.ValueObjects;

namespace Ollix.Domain.ClientAppAggregate.Specifications
{
    public class GetCompanyByCnpjSpec : SingleResultSpecification<ClientApp>
    {
        public GetCompanyByCnpjSpec(CNPJ cnpj)
        {
            Query.Where(u => u.Cnpj!.Value == cnpj.Value);
        }
    }
}
