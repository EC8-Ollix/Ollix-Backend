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
using Ollix.Domain.Aggregates.ClientAppAggregate.Specifications;

namespace Ollix.Application.UseCases.Clients.Queries.GetClients
{
    public sealed class GetClientsQueryHandler : IRequestHandler<GetClientsQuery, Result<PaginationResponse<ClientApp>>>
    {
        private readonly IRepository<ClientApp> _repository;

        public GetClientsQueryHandler(IRepository<ClientApp> repository)
        {
            _repository = repository;
        }

        public async Task<Result<PaginationResponse<ClientApp>>> Handle(GetClientsQuery query,
            CancellationToken cancellationToken)
        {
            var clientsCount = await _repository.CountAsync(new ClientsSpec(query.PaginationRequest), cancellationToken);
            var clientsResult = await _repository.ListAsync(new ClientsSpec(query.PaginationRequest), cancellationToken);
            
            return Result.Success(new PaginationResponse<ClientApp>(clientsResult, clientsCount, query.PaginationRequest));
        }
    }
}
