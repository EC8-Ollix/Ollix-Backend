using System.ComponentModel;

namespace Ollix.Domain.Aggregates.UserAppAggregate
{
    public enum UserType
    {
        [Description("Admin")]
        Admin,
        [Description("Client")]
        Client
    }
}
