using Ardalis.Result;
using MediatR;
using Ollix.Domain.Aggregates.UserAppAggregate.Models;

namespace Ollix.Application.UseCases.Propellers.Commands.TogglePropeller
{
    public sealed record TogglePropellerCommand(UserInfo UserInfo, Guid PropellerId)
        : IRequest<Result>;
}
