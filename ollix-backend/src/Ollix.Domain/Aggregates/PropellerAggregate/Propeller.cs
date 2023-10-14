using Ollix.Domain.Abstractions;
using Ollix.Domain.Aggregates.AddressAppAggregate;
using Ollix.Domain.Aggregates.ClientAppAggregate;
using Ollix.Domain.Aggregates.PropellerInfoAggregate;
using Ollix.SharedKernel;

namespace Ollix.Domain.Aggregates.PropellerAggregate
{
    public class Propeller : EntityBase, IClientAppEntity
    {
        public string? HelixId { get; set; }
        public bool Active { get; set; }
        public Guid AddressId { get; set; }
        public Guid ClientId { get; set; }

        public ICollection<PropellerInfoDate>? PropellerInfoDates { get; } = new List<PropellerInfoDate>();
        //public ICollection<PropellerInfoHistoric>? PropellerInfoHistorics { get; } = new List<PropellerInfoHistoric>();
        public AddressApp? AddressApp { get; set; }
        public ClientApp? ClientApp { get; set; }
    }
}
