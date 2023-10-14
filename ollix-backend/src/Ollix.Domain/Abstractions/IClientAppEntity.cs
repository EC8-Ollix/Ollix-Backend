using Ollix.Domain.Aggregates.ClientAppAggregate;

namespace Ollix.Domain.Abstractions
{
    public interface IClientAppEntity
    {
        public Guid ClientId { get; }
        public ClientApp? ClientApp { get; set; }
    }
}
