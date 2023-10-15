using System.ComponentModel;

namespace Ollix.Domain.Aggregates.LogAggregate
{
    public enum EntityEnum
    {
        [Description("Usuário")]
        User = 1,
        [Description("Cliente")]
        Client = 2,
        [Description("Pedido")]
        Order = 3,
        [Description("Hélice")]
        Propeller = 4
    }
}
