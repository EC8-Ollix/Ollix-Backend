using Ardalis.Specification;
using Ollix.Domain.Aggregates.UserAppAggregate;
using Ollix.Domain.Models;
using Ollix.Domain.ValueObjects;

namespace Ollix.Domain.Aggregates.ClientAppAggregate.Specifications
{
    public class GetClientsSpec : Specification<ClientApp>
    {
        public GetClientsSpec(PaginationRequest paginationRequest)
        {
            paginationRequest.NormalizePager();

            Query
                .Skip(paginationRequest.GetSkip())
                .Take(paginationRequest.PageSize);
        }
    }
}
