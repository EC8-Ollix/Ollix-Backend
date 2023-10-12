using Ardalis.Result;
using Ardalis.Specification;
using MediatR;
using Ollix.Application.Shared;
using Ollix.Application.UseCases.Clients.Queries.GetClientById;
using Ollix.Domain.Aggregates.ClientAppAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate.Specifications;
using Ollix.Domain.Models;
using Ollix.SharedKernel.Interfaces;

namespace Ollix.Application.UseCases.Users.Queries.GetUsers
{

    public sealed class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, Result<PaginationResponse<UserInfo>>>
    {
        private readonly IRepository<UserApp> _repository;
        private readonly IMediator _mediator;

        public GetUsersQueryHandler(IRepository<UserApp> repository,
            IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<Result<PaginationResponse<UserInfo>>> Handle(GetUsersQuery query,
            CancellationToken cancellationToken)
        {
            var clientAppResult = await _mediator.Send(new GetClientByIdQuery(query.UserInfo, query.ClientId), cancellationToken);
            if (!clientAppResult.IsSuccess)
                return Result.Error(clientAppResult.Errors.ToArray());

            var users = await _repository
                .ListAsync(new GetUsersSpec(query.PaginationRequest, clientAppResult.Value), cancellationToken);

            var countUsers = await _repository
                .CountAsync(new GetUsersSpec(clientAppResult.Value), cancellationToken);

            var usersResult = new PaginationResponse<UserInfo>
                (users.Select(u => new UserInfo(u)), countUsers, query.PaginationRequest);

            return Result.Success(usersResult);
        }   
    }
}
