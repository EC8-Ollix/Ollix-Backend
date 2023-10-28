using Ardalis.Result;
using MediatR;
using Ollix.Domain.Aggregates.ClientAppAggregate;
using Ollix.Domain.Aggregates.ClientAppAggregate.Specifications;
using Ollix.Domain.Models;
using Ollix.SharedKernel.Interfaces;

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
            var clientSpec = new ClientsSpec();
            clientSpec.WithBaseSpec(
                query.CompanyName, 
                query.BussinessName,
                query.Cnpj,
                query.Active);

            var clientsCount = await _repository.CountAsync(clientSpec, cancellationToken);

            clientSpec.WithPagination(query.PaginationRequest);
            var clientsResult = await _repository.ListAsync(clientSpec, cancellationToken);

            return Result.Success(new PaginationResponse<ClientApp>(clientsResult, clientsCount, query.PaginationRequest));
        }
    }
}
