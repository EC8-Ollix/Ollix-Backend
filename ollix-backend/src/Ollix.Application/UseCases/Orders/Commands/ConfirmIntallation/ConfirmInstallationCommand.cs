using Ardalis.Result;
using MediatR;
using Ollix.Domain.Aggregates.OrderAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate.Models;

namespace Ollix.Application.UseCases.Orders.Commands.ConfirmIntallation
{
    public sealed record ConfirmInstallationCommand(Guid OrderId, UserInfo UserInfo)
        : IRequest<Result<Order>>;
}
