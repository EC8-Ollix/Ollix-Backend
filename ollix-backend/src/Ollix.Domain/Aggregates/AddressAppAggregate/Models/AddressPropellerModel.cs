using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Domain.Aggregates.AddressAppAggregate.Models
{
    public class AddressPropellerModel
    {
        public AddressApp? Address { get; set; }
        public int PropellersCount { get; set; }

        public AddressPropellerModel(AddressApp address, int propellersCount)
        {
            Address = address;
            PropellersCount = propellersCount;
        }
    }
}
