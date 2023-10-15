﻿using Ardalis.Specification;
using Ollix.Domain.Aggregates.OrderAggregate;
using Ollix.Domain.Aggregates.PropellerAggregate.Models;
using Ollix.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Domain.Aggregates.PropellerAggregate.Specifications
{
    public class PropellersSpec : Specification<Propeller>
    {
        public PropellersSpec(PaginationRequest paginationRequest,
            Guid clientId, Guid orderId, Guid addressId, bool? active, bool? installed)
        {
            paginationRequest.NormalizePager();

            Query.Where(u => u.AddressId == addressId);
            Query.Where(u => u.ClientId == clientId);

            if (orderId != Guid.Empty)
                Query.Where(u => u.OrderId == orderId);

            if(active.HasValue)
                Query.Where(u => u.Active == active.Value);

            if (installed.HasValue)
                Query.Where(u => u.Active == installed.Value);

            Query
                .Skip(paginationRequest.GetSkip())
                .Take(paginationRequest.PageSize)
                .AsNoTracking();
        }

        public PropellersSpec(Guid clientId, Guid orderId, Guid addressId, bool? active, bool? installed)
        {
            Query.Where(u => u.AddressId == addressId);
            Query.Where(u => u.ClientId == clientId);

            if (orderId != Guid.Empty)
                Query.Where(u => u.OrderId == orderId);

            if (active.HasValue)
                Query.Where(u => u.Active == active.Value);

            if (installed.HasValue)
                Query.Where(u => u.Active == installed.Value);

            Query.AsNoTracking();
        }
    }
}
