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
        string? OrderNumber,
        string? RequesterSearch,
        string? ClientSearch,
        OrderStatus OrderStatus,
        DateTimeOffset[]? RequestedDate,
        PaginationRequest PaginationRequest) : IRequest<Result<PaginationResponse<Order>>>;
}
