using Ardalis.Result;
using MediatR;
using Ollix.Domain.Aggregates.UserAppAggregate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Application.UseCases.Clients.Commands.ToggleClient
{
    public sealed record ToggleClientCommand(UserInfo UserInfo, Guid ClientId)
        : IRequest<Result>;
}
