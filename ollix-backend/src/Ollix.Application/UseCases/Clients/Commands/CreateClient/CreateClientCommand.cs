using Ollix.Application.Abstractions;
using Ollix.Domain.ClientAppAggregate;
using Ollix.Domain.ValueObjects;
using Ollix.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Application.Authentication.Commands.Register
{
    public sealed record CreateClientCommand : ICommand<ClientApp>
    {
        public string? CompanyName { get; set; }
        public string? BussinessName { get; set; }
        public string? Cnpj { get; set; }
    }
}
