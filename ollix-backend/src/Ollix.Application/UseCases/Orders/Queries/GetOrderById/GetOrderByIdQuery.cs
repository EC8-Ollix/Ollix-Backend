using Ardalis.Result;
using MediatR;
using Ollix.Domain.Aggregates.OrderAggregate;

namespace Ollix.Application.UseCases.Orders.Queries.GetOrderById
{
    public sealed record GetOrderByIdQuery(Guid OrderId)
        : IRequest<Result<Order>>;
}
