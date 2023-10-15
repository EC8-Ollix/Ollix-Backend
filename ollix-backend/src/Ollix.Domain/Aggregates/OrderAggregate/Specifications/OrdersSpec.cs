using Ardalis.Specification;
using Ollix.Domain.Models;
using System.Data.Entity;

namespace Ollix.Domain.Aggregates.OrderAggregate.Specifications
{
    public class OrdersSpec : Specification<Order>
    {
        public OrdersSpec(PaginationRequest paginationRequest,
            Guid clientId, OrderStatus orderStatus, DateTimeOffset? requestedDate)
        {
            paginationRequest.NormalizePager();

            if (clientId != Guid.Empty)
                Query.Where(u => u.ClientId == clientId);

            if (requestedDate.HasValue)
                Query.Where(u => u.RequestDate.Date == requestedDate.Value.Date);

            Query
                .Where(u =>
                    u.OrderStatus == orderStatus)
                .Skip(paginationRequest.GetSkip())
                .Take(paginationRequest.PageSize)
                .AsNoTracking();
        }

        public OrdersSpec(Guid clientId,
            OrderStatus orderStatus, DateTimeOffset? requestedDate)
        {
            if (clientId != Guid.Empty)
                Query.Where(u => u.ClientId == clientId);

            if (requestedDate.HasValue)
                Query.Where(u => u.RequestDate.Date == requestedDate.Value.Date);

            Query.Where(u => u.OrderStatus == orderStatus).AsNoTracking();
        }
    }
}
