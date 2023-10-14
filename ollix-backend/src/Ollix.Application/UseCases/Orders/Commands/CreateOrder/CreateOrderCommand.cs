using Ardalis.Result;
using MediatR;
using Ollix.Domain.Aggregates.OrderAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate.Models;

namespace Ollix.Application.UseCases.Orders.Commands.CreateOrder
{
    public sealed record CreateOrderCommand : IRequest<Result<Order>>
    {
        public string? RequesterName { get; set; }
        public string? RequesterEmail { get; set; }
        public string? Observation { get; set; }
        public int QuantityRequested { get; set; }
        public string? PostalCode { get; set; }
        public UserInfo? UserInfo { get; set; }
    }
}
