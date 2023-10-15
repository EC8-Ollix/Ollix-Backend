using Ollix.Domain.Abstractions;
using Ollix.Domain.Aggregates.AddressAppAggregate;
using Ollix.Domain.Aggregates.ClientAppAggregate;
using Ollix.Domain.Aggregates.OrderAggregate;
using Ollix.Domain.Aggregates.PropellerInfoAggregate;
using Ollix.SharedKernel;

namespace Ollix.Domain.Aggregates.PropellerAggregate
{
    public class Propeller : EntityBase, IClientAppEntity
    {
        public string? HelixId { get; set; }
        public bool Active { get; set; }
        public bool Installed { get; set; }
        public Guid AddressId { get; set; }
        public Guid ClientId { get; set; }
        public Guid OrderId { get; set; }

        public ICollection<PropellerInfoDate>? PropellerInfoDates { get; } = new List<PropellerInfoDate>();
        public AddressApp? AddressApp { get; set; }
        public ClientApp? ClientApp { get; set; }
        public Order? Order { get; set; }

        public Propeller() { }

        public Propeller(Order order)
        {
            HelixId = $"urn:ngsi-ld:Helice:{Id.ToString()[..6]}";
            Active = false;
            Installed = false;
            AddressId = order.AddressId;
            OrderId = order.Id;
            ClientId = order.ClientId;
        }

        public void ToggleActive() => Active = !Active;
    }
}
