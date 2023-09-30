using Ardalis.Specification;
using Ollix.Domain.UserAggregate;

namespace Ollix.Domain.UserAppAggregate.Specifications
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
