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

namespace Ollix.Application.UseCases.Clients.Queries.GetClientById
{
    public sealed class GetClientsQueryHandler : IRequestHandler<GetClientByIdQuery, Result<ClientApp>>
    {
        private readonly IRepository<ClientApp> _repository;

        public GetClientsQueryHandler(IRepository<ClientApp> repository)
        {
            _repository = repository;
        }

        public async Task<Result<ClientApp>> Handle(GetClientByIdQuery query,
            CancellationToken cancellationToken)
        {
            var clientId = query.ClientId != Guid.Empty ? query.ClientId : query.UserInfo.ClientApp!.Id;

            var clientApp = await _repository.GetByIdAsync(clientId, cancellationToken);
            if (clientApp is null)
                return Result.NotFound("Cliente não encontrado!");

            return Result.Success(clientApp);
        }
    }
}
