using Ardalis.Result;
using MediatR;
using Ollix.Domain.Aggregates.OrderAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Application.UseCases.Orders.Commands.ProcessOrder
{

    public sealed record ProcessOrderCommand : IRequest<Result<Order>>
    {
        public Guid OrderId { get; set; }
        public bool Approved { get; set; }
        public DateTimeOffset IntallationDate { get; set; }
        public UserInfo? UserInfo { get; set; }
    }
}
