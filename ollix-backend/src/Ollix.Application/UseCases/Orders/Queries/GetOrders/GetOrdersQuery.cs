using Ardalis.Result;
using MediatR;
using Ollix.Domain.Aggregates.OrderAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate.Models;
using Ollix.Domain.Models;

namespace Ollix.Application.UseCases.Orders.Queries.GetOrders
{
    public sealed record GetOrdersQuery(
        UserInfo UserInfo,
        Guid ClientId,
        OrderStatus OrderStatus,
        DateTimeOffset? RequestedDate,
        PaginationRequest PaginationRequest) : IRequest<Result<PaginationResponse<Order>>>;
}
