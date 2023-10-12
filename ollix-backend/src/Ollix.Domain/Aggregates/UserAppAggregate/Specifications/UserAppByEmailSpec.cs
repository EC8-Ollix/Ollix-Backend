using Ardalis.Specification;

namespace Ollix.Domain.Aggregates.UserAppAggregate.Specifications
{
    public class UserAppByEmailSpec : SingleResultSpecification<UserApp>
    {
        public UserAppByEmailSpec(string email)
        {
            if (!string.IsNullOrEmpty(email))
                Query.Where(u => u.UserEmail! == email);
        }
    }
}
