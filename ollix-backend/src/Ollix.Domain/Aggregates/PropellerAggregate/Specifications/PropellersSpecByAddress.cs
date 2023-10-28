using Ardalis.Specification;
using Ollix.Domain.Aggregates.AddressAppAggregate;
using Ollix.SharedKernel.Extensions;

namespace Ollix.Domain.Aggregates.PropellerAggregate.Specifications
{
    public class PropellersSpecByAddress : Specification<Propeller, AddressApp>
    {
        public PropellersSpecByAddress(Guid clientId,
                                       string? postalCode,
                                       string? street,
                                       string? neighborhood,
                                       string? state,
                                       string? city)
        {
            Query.Where(u => u.ClientId == clientId && u.Installed == true);
            Query.Select(p => p.AddressApp!).Include(p => p.AddressApp!);

            if (!string.IsNullOrEmpty(postalCode))
            {
                Query.Where(u => u.AddressApp!.PostalCode!.Contains(postalCode.JustNumbers().ToTrim()));
            }
            else
            {
                if (!string.IsNullOrEmpty(street))
                    Query.Where(u => u.AddressApp!.Street!.Contains(street.ToTrim()));

                if (!string.IsNullOrEmpty(neighborhood))
                    Query.Where(u => u.AddressApp!.Neighborhood!.Contains(neighborhood.ToTrim()));

                if (!string.IsNullOrEmpty(state))
                    Query.Where(u => u.AddressApp!.State!.Contains(state.ToTrim()));

                if (!string.IsNullOrEmpty(city))
                    Query.Where(u => u.AddressApp!.City!.Contains(city.ToTrim()));
            }

            Query.AsNoTracking();
        }
    }
}
