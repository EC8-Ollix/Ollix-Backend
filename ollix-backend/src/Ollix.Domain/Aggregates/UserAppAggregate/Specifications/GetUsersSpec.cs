using Ardalis.Specification;
using Ollix.Domain.Aggregates.ClientAppAggregate;
using Ollix.Domain.Models;

namespace Ollix.Domain.Aggregates.UserAppAggregate.Specifications
{
    public class GetUsersSpec : Specification<UserApp>
    {
        public GetUsersSpec(PaginationRequest paginationRequest, ClientApp client)
        {
            paginationRequest.NormalizePager();

            Query
                .Where(u => u.ClientId == client.Id)
                .Skip(paginationRequest.GetSkip())
                .Take(paginationRequest.PageSize);
        }

        public GetUsersSpec(ClientApp client)
        {
            Query
                .Where(u => u.ClientId == client.Id);
        }
    }
}
