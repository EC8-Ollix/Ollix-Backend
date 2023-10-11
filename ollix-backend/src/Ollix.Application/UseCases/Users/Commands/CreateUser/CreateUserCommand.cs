using Ardalis.Result;
using MediatR;
using Ollix.Application.Shared;
using Ollix.Application.UseCases.Clients.Commands.CreateClient;
using Ollix.Application.UseCases.Users.Commands.Shared;
using Ollix.Domain.Aggregates.UserAppAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Application.UseCases.Users.Commands.CreateUser
{
    public sealed record CreateUserCommand : UpsertUserCommand, IRequest<Result<UserInfo>>
    {
        public string? UserEmail { get; set; }
    }
}
