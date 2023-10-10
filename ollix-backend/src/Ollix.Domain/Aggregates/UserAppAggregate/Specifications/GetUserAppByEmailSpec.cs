using Ardalis.Specification;

namespace Ollix.Domain.Aggregates.UserAppAggregate.Specifications
{
    public class GetUserAppByEmailSpec : SingleResultSpecification<UserApp>
    {
        public GetUserAppByEmailSpec(string email)
        {
            if (!string.IsNullOrEmpty(email))
                Query.Where(u => u.UserEmail! == email);
        }
    }
}
