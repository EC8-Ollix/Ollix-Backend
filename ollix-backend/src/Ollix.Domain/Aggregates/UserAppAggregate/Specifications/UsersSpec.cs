using Ardalis.Specification;
using Ollix.Domain.Aggregates.ClientAppAggregate;
using Ollix.Domain.Models;

namespace Ollix.Domain.Aggregates.UserAppAggregate.Specifications
{
    public class UsersSpec : Specification<UserApp>
    {
        public UsersSpec(PaginationRequest paginationRequest, ClientApp client)
        {
            paginationRequest.NormalizePager();

            Query
                .Where(u => u.ClientId == client.Id)
                .Skip(paginationRequest.GetSkip())
                .Take(paginationRequest.PageSize);
        }

        public UsersSpec(ClientApp client)
        {
            Query
                .Where(u => u.ClientId == client.Id);
        }
    }
}
