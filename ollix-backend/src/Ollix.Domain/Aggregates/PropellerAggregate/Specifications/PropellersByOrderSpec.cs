using Ardalis.Specification;
using Ollix.Domain.Aggregates.OrderAggregate;
using Ollix.Domain.Models;

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
