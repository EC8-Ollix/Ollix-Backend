using Ardalis.Result;
using MediatR;
using Ollix.Domain.Aggregates.OrderAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate.Models;

namespace Ollix.Application.UseCases.Propellers.Commands.InstallPropellers
{
    public record InstallPropellersCommand(Order Order, UserInfo UserInfo)
        : IRequest<Result>;
}
