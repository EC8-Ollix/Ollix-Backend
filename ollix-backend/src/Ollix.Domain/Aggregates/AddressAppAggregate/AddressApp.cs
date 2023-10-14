using Ollix.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Domain.Aggregates.AddressAppAggregate
{
    public class AddressApp : EntityBase
    {
        public string? PostalCode { get; private set; }
        public string? Street { get; private set; }
        public string? Number { get; private set; }
        public string? Complement { get; private set; }
        public string? Neighborhood { get; private set; }
        public string? City { get; private set; }
        public string? State { get; private set; }

        public AddressApp() { }

        public AddressApp(string postalCode, string street, string number, string neighborhood,
                          string city, string state, string? complement = null)
        {
            PostalCode = postalCode;
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Complement = complement;
        }
    }
}
