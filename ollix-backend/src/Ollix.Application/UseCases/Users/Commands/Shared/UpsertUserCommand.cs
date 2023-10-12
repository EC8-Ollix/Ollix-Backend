using Ollix.Application.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Application.UseCases.Users.Commands.Shared
{
    public record UpsertUserCommand
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserPassword { get; set; }
        public UserInfo? UserInfo { get; set; }
    }
}
