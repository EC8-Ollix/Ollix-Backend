using Ardalis.Result;
using MediatR;
using Ollix.Domain.Aggregates.AddressAppAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate.Models;

namespace Ollix.Application.UseCases.Adresses.Queries.GetAdressesByClient
{
    public sealed record GetAdressesByClientQuery(
        UserInfo UserInfo,
        Guid ClientId) : IRequest<Result<AddressApp[]>>;
}
