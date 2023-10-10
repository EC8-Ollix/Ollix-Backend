using Ardalis.Result;
using MediatR;
using Ollix.Application.Shared;
using Ollix.Domain.Models;

namespace Ollix.Application.UseCases.Users.Queries.GetUsers
{
    public sealed record GetUsersQuery(PaginationRequest paginationRequest)
        : IRequest<Result<PaginationResponse<UserInfo>>>;

}
