using Ardalis.Specification;
using Ollix.SharedKernel.Extensions;

namespace Ollix.Domain.Aggregates.AddressAppAggregate.Specifications
{
    public class AdressByPostalCode : SingleResultSpecification<AddressApp>
    {
        public AdressByPostalCode(string postalCode)
        {
            Query
                .Where(p => p.PostalCode == postalCode.JustNumbers()).AsNoTracking();
        }
    }
}
