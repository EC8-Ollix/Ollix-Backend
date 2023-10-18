using Ardalis.Result;
using MediatR;
using Ollix.Application.UseCases.Clients.Commands.Shared;
using Ollix.Domain.Aggregates.ClientAppAggregate;

namespace Ollix.Application.UseCases.Clients.Commands.CreateClient
{
    public sealed record CreateClientCommand : UpsertClientCommand, IRequest<Result<ClientApp>>
    {
        public string? Cnpj { get; set; }
    }
}
