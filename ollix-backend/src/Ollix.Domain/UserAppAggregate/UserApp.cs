using Ollix.Domain.Abstractions;
using Ollix.Domain.ClientAppAggregate;
using Ollix.Domain.ValueObjects;
using Ollix.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Domain.UserAggregate
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
