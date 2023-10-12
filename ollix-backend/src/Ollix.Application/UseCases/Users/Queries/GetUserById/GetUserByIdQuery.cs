using Ardalis.Result;
using MediatR;
using Ollix.Domain.Aggregates.UserAppAggregate;

namespace Ollix.Application.UseCases.Users.Queries.GetUserById
{
    public sealed record GetUserByIdQuery(Guid UserId)
        : IRequest<Result<UserApp>>;
}
