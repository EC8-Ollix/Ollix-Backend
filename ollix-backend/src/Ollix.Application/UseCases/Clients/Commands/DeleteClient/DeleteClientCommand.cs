using Ardalis.Result;
using MediatR;
using Ollix.Domain.Aggregates.UserAppAggregate.Models;

namespace Ollix.Application.UseCases.Clients.Commands.DeleteClient
{
    public sealed record DeleteClientCommand(UserInfo UserInfo, Guid ClientId)
        : IRequest<Result>;
}
