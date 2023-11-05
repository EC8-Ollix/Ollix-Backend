using Ardalis.Result;
using MediatR;
using Ollix.Domain.Aggregates.ClientAppAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate.Models;
using Ollix.Domain.Models;

namespace Ollix.Application.UseCases.Clients.Queries.GetClients
{
    public sealed record GetClientsQuery(UserInfo UserInfo, PaginationRequest PaginationRequest,
        string? CompanyName, string? BussinessName, string? Cnpj, bool? Active)
        : IRequest<Result<PaginationResponse<ClientApp>>>;
}
