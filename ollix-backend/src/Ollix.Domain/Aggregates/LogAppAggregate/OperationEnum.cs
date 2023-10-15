using System.ComponentModel;

namespace Ollix.Domain.Aggregates.LogAggregate
{
    public enum OperationEnum
    {
        [Description("Criação")]
        Create = 1,
        [Description("Edição")]
        Update = 2,
        [Description("Exclusão")]
        Delete = 3,
        [Description("Cancelamento")]
        Cancel = 4,
        [Description("Pedido Processado")]
        ProcessOrder = 5,
        [Description("Pedido Finalizado")]
        OrderCompleted = 6,
        [Description("Hélice Instalada")]
        PropellerInstalled = 7,
        [Description("Cliente Ativado")]
        ActiveClient = 8,
        [Description("Cliente Desativado")]
        InactiveClient = 9,
        [Description("Hélice Ativada")]
        ActivePropeller = 10,
        [Description("Hélice Desativada")]
        InactivePropeller = 11
    }
}
