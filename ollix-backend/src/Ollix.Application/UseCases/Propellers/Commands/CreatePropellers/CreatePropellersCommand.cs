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

namespace Ollix.Application.UseCases.Propellers.Commands.CreatePropellers
{
    public sealed record CreatePropellersCommand(Order Order, UserInfo UserInfo) 
        : IRequest<Result>;
}
