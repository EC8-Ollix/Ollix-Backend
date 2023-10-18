using Ardalis.Result;
using MediatR;
using Ollix.Domain.Aggregates.UserAppAggregate.Models;

namespace Ollix.Application.UseCases.Users.Commands.DeleteUser
{
    public sealed record DeleteUserCommand(UserInfo UserInfo, Guid UserId)
        : IRequest<Result>;
}
