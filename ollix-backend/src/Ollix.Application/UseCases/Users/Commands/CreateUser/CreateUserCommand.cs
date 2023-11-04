using Ardalis.Result;
using MediatR;
using Ollix.Application.UseCases.Users.Commands.Shared;
using Ollix.Domain.Aggregates.UserAppAggregate.Models;

namespace Ollix.Application.UseCases.Users.Commands.CreateUser
{
    public sealed record CreateUserCommand : UpsertUserCommand, IRequest<Result<UserInfo>>
    {
        public string? UserEmail { get; set; }
        public string? UserPassword { get; set; }
    }
}
