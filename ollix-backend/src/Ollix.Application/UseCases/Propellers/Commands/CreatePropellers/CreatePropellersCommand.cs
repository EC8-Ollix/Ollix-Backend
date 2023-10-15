using Ardalis.Result;
using MediatR;
using Ollix.Domain.Aggregates.OrderAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate.Models;

namespace Ollix.Application.UseCases.Propellers.Commands.CreatePropellers
{
    public sealed record CreatePropellersCommand(Order Order, UserInfo UserInfo)
        : IRequest<Result>;
}
