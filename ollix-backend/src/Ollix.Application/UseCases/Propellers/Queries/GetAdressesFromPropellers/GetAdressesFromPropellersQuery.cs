using Ardalis.Result;
using MediatR;
using Ollix.Domain.Aggregates.AddressAppAggregate.Models;
using Ollix.Domain.Aggregates.UserAppAggregate.Models;
using Ollix.Domain.Models;

namespace Ollix.Application.UseCases.Propellers.Queries.GetAdressesFromPropellers
{
    public sealed record GetAdressesFromPropellersQuery(
        UserInfo UserInfo,
        Guid ClientId,
        string? PostalCode,
        string? Street,
        string? Neighborhood,
        string? State,
        string? City,
        PaginationRequest PaginationRequest) : IRequest<Result<PaginationResponse<AddressPropellerModel>>>;
}
