using Ardalis.Specification;
using Ollix.Domain.Aggregates.ClientAppAggregate;
using Ollix.Domain.Aggregates.LogAggregate;
using Ollix.Domain.Aggregates.LogAppAggregate.Models;
using Ollix.Domain.Aggregates.OrderAggregate;
using Ollix.Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Domain.Aggregates.PropellerAggregate.Specifications
{
    public class PropellersByOrderSpec : Specification<Propeller>
    {
        public PropellersByOrderSpec(PaginationRequest paginationRequest, Order order)
        {
            paginationRequest.NormalizePager();

            Query
                .Where(q => q.OrderId == order.Id)
                .Skip(paginationRequest.GetSkip())
                .Take(paginationRequest.PageSize)
                .AsNoTracking();
        }

        public PropellersByOrderSpec(Order order)
        {
            Query.Where(q => q.OrderId == order.Id).AsNoTracking();
        }
    }
}
