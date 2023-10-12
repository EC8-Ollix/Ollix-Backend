using Ardalis.Result;
using MediatR;
using Ollix.Application.Shared;
using Ollix.Domain.Models;

namespace Ollix.Application.UseCases.Users.Queries.GetUsers
{
    public sealed record GetUsersQuery(UserInfo UserInfo, Guid ClientId, PaginationRequest PaginationRequest)
        : IRequest<Result<PaginationResponse<UserInfo>>>;

}
