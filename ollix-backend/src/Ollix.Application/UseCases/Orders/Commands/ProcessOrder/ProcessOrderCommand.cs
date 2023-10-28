using Ardalis.Result;
using MediatR;
using Ollix.Domain.Aggregates.OrderAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate.Models;

namespace Ollix.Application.UseCases.Orders.Commands.ProcessOrder
{

    public sealed record ProcessOrderCommand : IRequest<Result<Order>>
    {
        public Guid OrderId { get; set; }
        public bool Approved { get; set; }
        public DateTimeOffset InstallationDate { get; set; }
        public UserInfo? UserInfo { get; set; }
    }
}
