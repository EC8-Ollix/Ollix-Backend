using Ollix.Domain.Aggregates.AddressAppAggregate;

namespace Ollix.Domain.Aggregates.PropellerAggregate.Models
{
    public class PropellersByAdressModel
    {
        public AddressApp? Address { get; set; }
        public int PropellersCount { get; set; }
    }
}
