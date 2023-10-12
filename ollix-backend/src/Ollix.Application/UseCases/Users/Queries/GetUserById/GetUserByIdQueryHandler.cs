using Ardalis.Result;
using MediatR;
using Ollix.Application.Shared;
using Ollix.Application.UseCases.Users.Queries.GetUsers;
using Ollix.Domain.Aggregates.ClientAppAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate.Specifications;
using Ollix.Domain.Aggregates.UserAppAggregate;
using Ollix.Domain.Models;
using Ollix.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
