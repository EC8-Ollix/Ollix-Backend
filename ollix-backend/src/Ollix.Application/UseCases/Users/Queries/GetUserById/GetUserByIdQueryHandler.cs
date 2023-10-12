using Ardalis.Result;
using MediatR;
using Ollix.Domain.Aggregates.UserAppAggregate;
using Ollix.SharedKernel.Interfaces;

namespace Ollix.Application.UseCases.Users.Queries.GetUserById
{
    public sealed class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Result<UserApp>>
    {
        private readonly IRepository<UserApp> _repository;

        public GetUserByIdQueryHandler(IRepository<UserApp> repository)
        {
            _repository = repository;
        }

        public async Task<Result<UserApp>> Handle(GetUserByIdQuery query,
            CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(query.UserId, cancellationToken);
            if (user is null)
                return Result.NotFound("Usuário não encontrado!");

            return Result.Success(user);
        }
    }
}
