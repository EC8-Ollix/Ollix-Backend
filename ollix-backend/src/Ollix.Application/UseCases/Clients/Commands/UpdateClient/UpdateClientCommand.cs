using Ardalis.Result;
using MediatR;
using Ollix.Application.UseCases.Clients.Commands.Shared;
using Ollix.Domain.Aggregates.ClientAppAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate.Models;

namespace Ollix.Application.UseCases.Clients.Commands.CreateClient
{
    public sealed record UpdateClientCommand : UpsertClientCommand, IRequest<Result<ClientApp>>
    {
        public Guid ClientId { get; set; }
        public UserInfo? UserInfo { get; set; }
    }
}
