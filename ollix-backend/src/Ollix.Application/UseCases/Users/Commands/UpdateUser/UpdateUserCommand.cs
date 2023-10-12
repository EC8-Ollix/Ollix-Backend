using Ardalis.Result;
using MediatR;
using Ollix.Application.UseCases.Users.Commands.Shared;
using Ollix.Domain.Aggregates.UserAppAggregate.Models;

namespace Ollix.Application.UseCases.Users.Commands.UpdateUser
{
    public sealed record UpdateUserCommand : UpsertUserCommand, IRequest<Result<UserInfo>>
    {
        public Guid UserId { get; set; }
    }
}
