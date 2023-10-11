using Ardalis.Result;
using MediatR;
using Ollix.Application.Shared;
using Ollix.Application.UseCases.Clients.Commands.Shared;
using Ollix.Domain.Aggregates.ClientAppAggregate;

namespace Ollix.Application.UseCases.Clients.Commands.CreateClient
{
    public sealed record UpdateClientCommand : UpsertClientCommand, IRequest<Result<ClientApp>>
    {
        public Guid ClientId { get; set; }
        public UserInfo? UserInfo { get; set; }
    }
}
