using Ardalis.Result;
using MediatR;
using Ollix.Domain.Aggregates.UserAppAggregate.Models;

namespace Ollix.Application.UseCases.Orders.Commands.CancelOrder
{
    public sealed record CancelOrderCommand(UserInfo UserInfo, Guid OrderId)
        : IRequest<Result>;
}
