using Ollix.SharedKernel;

namespace Ollix.Domain.Aggregates.AddressAppAggregate
{
    public class AddressApp : EntityBase
    {
        public string? PostalCode { get; private set; }
        public string? Street { get; private set; }
        public string? Neighborhood { get; private set; }
        public string? City { get; private set; }
        public string? State { get; private set; }

        public AddressApp() { }

        public AddressApp(string postalCode, string street, string neighborhood,
                          string city, string state)
        {
            PostalCode = postalCode;
            Street = street;
            Neighborhood = neighborhood;
            City = city;
            State = state;
        }
    }
}
