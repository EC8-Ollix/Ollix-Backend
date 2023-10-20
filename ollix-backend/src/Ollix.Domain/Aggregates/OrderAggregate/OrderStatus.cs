using System.ComponentModel;

namespace Ollix.Domain.Aggregates.OrderAggregate
{
    public enum OrderStatus
    {
        [Description("Pendente")]
        Pending = 1,

        [Description("Instalação Pendente")]
        InstallationPending = 2,

        [Description("Finalizado")]
        Completed = 3,

        [Description("Negado")]
        Denied = 4,

        [Description("Cancelado")]
        Cancel = 5
    }
}
