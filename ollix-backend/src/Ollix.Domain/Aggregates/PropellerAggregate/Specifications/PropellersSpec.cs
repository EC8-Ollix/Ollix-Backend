using Ardalis.Specification;
using Ollix.Domain.Models;

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

            if (active.HasValue)
                Query.Where(u => u.Active == active.Value);

            if (installed.HasValue)
                Query.Where(u => u.Installed == installed.Value);

            Query
                .Include(i => i.AddressApp)
                .Include(i => i.Order)
                .OrderByDescending(i => i.Order!.InstallationDate)
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
                Query.Where(u => u.Installed == installed.Value);

            Query.AsNoTracking();
        }
    }
}
