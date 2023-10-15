using Ardalis.Result;
using MediatR;
using Ollix.Domain.Aggregates.UserAppAggregate.Models;

namespace Ollix.Application.UseCases.Clients.Commands.ToggleClient
{
    public sealed record ToggleClientCommand(UserInfo UserInfo, Guid ClientId)
        : IRequest<Result>;
}
