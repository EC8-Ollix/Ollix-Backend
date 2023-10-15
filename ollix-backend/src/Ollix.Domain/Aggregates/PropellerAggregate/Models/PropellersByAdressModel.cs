using Ollix.Domain.Aggregates.AddressAppAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Domain.Aggregates.PropellerAggregate.Models
{
    public class PropellersByAdressModel
    {
        public AddressApp? Address { get; set; }
        public int PropellersCount { get; set; }
    }
}
