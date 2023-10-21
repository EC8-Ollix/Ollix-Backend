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

            if(orderStatus != 0)
                Query.Where(u =>u.OrderStatus == orderStatus);
            
            Query
                .Include(u => u.ClientApp)
                .OrderByDescending(o => o.RequestDate)
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

            if (orderStatus != 0)
                Query.Where(u => u.OrderStatus == orderStatus);

            Query.AsNoTracking();
        }
    }
}
