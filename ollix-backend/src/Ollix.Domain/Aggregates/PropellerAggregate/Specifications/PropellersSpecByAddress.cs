﻿using Ardalis.Specification;
using Ollix.Domain.Aggregates.AddressAppAggregate;

namespace Ollix.Domain.Aggregates.PropellerAggregate.Specifications
{
    public class PropellersSpecByAddress : Specification<Propeller, AddressApp>
    {
        public PropellersSpecByAddress(Guid clientId, string? state, string? city, bool? installed)
        {
            Query.Where(u => u.ClientId == clientId);

            Query.Select(p => p.AddressApp!)
                .Include(p => p.AddressApp!);

            if (installed.HasValue)
                Query.Where(u => u.Active == installed.Value);

            if (!string.IsNullOrEmpty(state))
                Query.Where(p => p.AddressApp!.State!.Contains(state));

            if (!string.IsNullOrEmpty(city))
                Query.Where(p => p.AddressApp!.City!.Contains(city));

            Query.AsNoTracking();
        }
    }
}