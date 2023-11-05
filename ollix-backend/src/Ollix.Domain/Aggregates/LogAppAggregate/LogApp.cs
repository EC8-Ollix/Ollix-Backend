using Ollix.Domain.Aggregates.ClientAppAggregate;
using Ollix.SharedKernel;

namespace Ollix.Domain.Aggregates.LogAggregate
{
    public class LogApp : EntityBase
    {
        public string? Identifier { get; set; }
        public EntityEnum? Entity { get; set; }
        public OperationEnum? Operation { get; set; }
        public Guid? EntityId { get; set; }
        public Guid ClientId { get; set; }
        public string? UserName { get; set; }
        public DateTimeOffset Date { get; set; }
        public ClientApp? ClientApp { get; set; }
    }
}
