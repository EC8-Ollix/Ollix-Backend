using Ollix.Application.Abstractions;
using Ollix.Application.Authentication.Commands.Register;
using Ollix.Application.UseCases.Authentication.Shared;
using Ollix.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Application.UseCases.Authentication.Commands.Register
{
    public sealed record RegisterCommand : ICommand<UserInfo>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPassword { get; set; }
        public CreateClientCommand? CreateClientCommand { get; set; }
    }
}
