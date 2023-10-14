using Ardalis.Result;
using MediatR;
using Ollix.Domain.Aggregates.OrderAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Application.UseCases.Orders.Queries.GetOrderById
{
    public sealed record GetOrderByIdQuery(Guid OrderId)
        : IRequest<Result<Order>>;
}
