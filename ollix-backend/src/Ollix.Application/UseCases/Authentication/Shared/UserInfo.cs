using Ollix.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Application.UseCases.Authentication.Shared
{
    public record UserInfo
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserEmail { get; set; }
        public Guid ClientId { get; set; }
        public UserType UserType { get; set; }

        public UserInfo(UserApp user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            UserEmail = user.UserEmail;
            ClientId = user.ClientId;
            UserType = user.UserType;
        }
    }
}
