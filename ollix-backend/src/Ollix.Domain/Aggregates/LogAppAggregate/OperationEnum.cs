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
    }
}
