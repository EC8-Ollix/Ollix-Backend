using Ardalis.Specification;
using Ollix.Domain.Models;

namespace Ollix.Domain.Aggregates.UserAppAggregate.Specifications
{
    public class GetUsersSpec : Specification<UserApp>
    {
        public GetUsersSpec(PaginationRequest paginationRequest)
        {
            paginationRequest.NormalizePager();

            Query
                .Skip(paginationRequest.GetSkip())
                .Take(paginationRequest.PageSize);
        }

        public GetUsersSpec()
        {
        }
    }
}
