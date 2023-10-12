using System.ComponentModel;

namespace Ollix.Domain.Aggregates.LogAggregate
{
    public enum EntityEnum
    {
        [Description("Usuário")]
        User = 1,
        [Description("Cliente")]
        Client = 2,
    }
}
