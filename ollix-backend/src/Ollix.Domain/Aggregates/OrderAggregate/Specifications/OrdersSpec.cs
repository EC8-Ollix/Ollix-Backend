using Ardalis.Specification;
using Ollix.Domain.Models;
using Ollix.SharedKernel.Extensions;
using System.Data.Entity;

namespace Ollix.Domain.Aggregates.OrderAggregate.Specifications
{
    public class OrdersSpec : Specification<Order>
    {
        public void WithBaseSpec(
                          Guid clientId,
                          string? orderNumber,
                          string? requesterSearch,
                          string? clientSearch,
                          OrderStatus orderStatus,
                          DateTimeOffset[]? requestedDate)
        {
            Query.Include(u => u.ClientApp);
            if (clientId != Guid.Empty)
                Query.Where(u => u.ClientId == clientId);

            if (requestedDate is not null && requestedDate.Any())
                Query.Where(u =>
                    u.RequestDate.Date >= requestedDate.First().Date &&
                    u.RequestDate.Date <= requestedDate.Last().Date
                );

            if (!string.IsNullOrEmpty(orderNumber))
                Query.Where(u => u.OrderNumber!.Contains(orderNumber.ToTrim()));
   
            if (!string.IsNullOrEmpty(requesterSearch))
            {
                requesterSearch = requesterSearch.ToTrim();
                Query.Search(u => u.RequesterName!, "%" + requesterSearch + "%")
                    .Search(u => u.RequesterEmail!, "%" + requesterSearch + "%");
            }
            if (!string.IsNullOrEmpty(clientSearch))
            {
                clientSearch = clientSearch.ToTrim();
                Query.Search(u => u.ClientApp!.CompanyName!, "%" + clientSearch + "%")
                    .Search(u => u.ClientApp!.BussinessName!, "%" + clientSearch + "%");            
            }

            if (orderStatus != 0)
                Query.Where(u => u.OrderStatus == orderStatus);

            Query.Include(u => u.AddressApp).AsNoTracking();
        }

        public void WithPagination(PaginationRequest paginationRequest)
        {
            paginationRequest.NormalizePager();
            Query
                .OrderByDescending(o => o.RequestDate)
                .Skip(paginationRequest.GetSkip())
                .Take(paginationRequest.PageSize);
        }
    }
}
