using Ardalis.Result;
using MediatR;
using Ollix.Application.Shared;
using Ollix.Domain.Aggregates.UserAppAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate.Specifications;
using Ollix.Domain.Models;
using Ollix.SharedKernel.Interfaces;

namespace Ollix.Application.UseCases.Users.Queries.GetUsers
{

    public sealed class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, Result<PaginationResponse<UserInfo>>>
    {
        private readonly IRepository<UserApp> _repository;

        public GetUsersQueryHandler(IRepository<UserApp> repository)
        {
            _repository = repository;
        }

        public async Task<Result<PaginationResponse<UserInfo>>> Handle(GetUsersQuery query,
            CancellationToken cancellationToken)
        {
            var users = await _repository
                .ListAsync(new GetUsersSpec(query.paginationRequest), cancellationToken);

            var countUsers = await _repository
                .CountAsync(new GetUsersSpec(), cancellationToken);

            var usersResult = new PaginationResponse<UserInfo>
                (users.Select(u => new UserInfo(u)), countUsers, query.paginationRequest.Page, query.paginationRequest.PageSize);

            return Result.Success(usersResult);
        }
    }

}
