using Ardalis.Specification;
using Ollix.Domain.Models;

namespace Ollix.Domain.Aggregates.ClientAppAggregate.Specifications
{
    public class ClientsSpec : Specification<ClientApp>
    {
        public ClientsSpec(PaginationRequest paginationRequest)
        {
            paginationRequest.NormalizePager();

            Query
                .Skip(paginationRequest.GetSkip())
                .Take(paginationRequest.PageSize);
        }
    }
}
