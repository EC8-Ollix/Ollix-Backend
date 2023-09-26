using Ollix.Domain.ClientAppAggregate;
using Ollix.Domain.Shared;
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
        public string? Email { get; set; }
        public string? Password { get; set; }
        public Guid? ClientAppId { get; set; }
        public bool IsLoggedIn { get; set; }
        public UserType UserType { get; set; }
    }
}
