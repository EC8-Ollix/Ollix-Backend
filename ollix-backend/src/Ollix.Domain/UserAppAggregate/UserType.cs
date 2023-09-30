using System.ComponentModel;

namespace Ollix.Domain.UserAggregate
{
    public enum UserType
    {
        [Description("ADMIN")]
        Admin,
        [Description("CLIENT")]
        Client
    }
}
