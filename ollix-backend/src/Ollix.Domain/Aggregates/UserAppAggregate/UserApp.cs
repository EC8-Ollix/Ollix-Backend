using Ollix.Domain.Abstractions;
using Ollix.SharedKernel;

namespace Ollix.Domain.Aggregates.UserAppAggregate
{
    public class UserApp : EntityBase, IClientAppEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Guid ClientId { get; set; }
        public UserType UserType { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPassword { get; set; }
    }
}
