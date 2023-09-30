using System.ComponentModel;

namespace Ollix.Domain.UserAggregate
{
    public enum UserType
    {
        [Description("Admin")]
        Admin,
        [Description("Client")]
        Client
    }
}
