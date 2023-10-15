using Ardalis.Result;
using MediatR;
using Ollix.Domain.Aggregates.PropellerAggregate;

namespace Ollix.Application.UseCases.Propellers.Queries.GetPropellerById
{
    public sealed record GetPropellerByIdQuery(Guid PropellerId)
        : IRequest<Result<Propeller>>;
}


