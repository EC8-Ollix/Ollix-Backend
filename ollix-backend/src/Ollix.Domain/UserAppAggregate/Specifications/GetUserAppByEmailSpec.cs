using Ardalis.Specification;
using Ollix.Domain.UserAggregate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
