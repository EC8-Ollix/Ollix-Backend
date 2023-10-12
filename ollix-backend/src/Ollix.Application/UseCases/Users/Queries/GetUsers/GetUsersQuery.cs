using Ardalis.Result;
using MediatR;
using Ollix.Application.Shared;
using Ollix.Domain.Models;

namespace Ollix.Application.UseCases.Users.Queries.GetUsers
{
    public sealed record GetUsersQuery(UserInfo UserInfo, PaginationRequest PaginationRequest, Guid ClientId)
        : IRequest<Result<PaginationResponse<UserInfo>>>;

}
