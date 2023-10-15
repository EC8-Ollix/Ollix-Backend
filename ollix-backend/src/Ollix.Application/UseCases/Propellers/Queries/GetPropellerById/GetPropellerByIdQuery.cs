using Ardalis.Result;
using MediatR;
using Ollix.Domain.Aggregates.OrderAggregate;
using Ollix.Domain.Aggregates.PropellerAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Application.UseCases.Propellers.Queries.GetPropellerById
{
    public sealed record GetPropellerByIdQuery(Guid PropellerId)
        : IRequest<Result<Propeller>>;
}


