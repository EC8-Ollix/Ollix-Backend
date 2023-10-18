using Ardalis.Result;
using MediatR;
using Ollix.Domain.Aggregates.ClientAppAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate.Models;

namespace Ollix.Application.UseCases.Clients.Queries.GetClientById
{
    public sealed record GetClientByIdQuery(UserInfo UserInfo, Guid ClientId)
        : IRequest<Result<ClientApp>>;
}
