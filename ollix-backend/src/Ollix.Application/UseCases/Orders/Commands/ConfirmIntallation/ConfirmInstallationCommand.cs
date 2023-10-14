using Ardalis.Result;
using MediatR;
using Ollix.Domain.Aggregates.OrderAggregate;
using Ollix.Domain.Aggregates.PropellerAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Application.UseCases.Orders.Commands.ConfirmIntallation
{
    public sealed record ConfirmInstallationCommand(Guid OrderId, UserInfo UserInfo)
        : IRequest<Result<Order>>;
}
