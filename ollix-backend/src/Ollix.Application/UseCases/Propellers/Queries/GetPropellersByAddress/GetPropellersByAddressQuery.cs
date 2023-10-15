using Ardalis.Result;
using MediatR;
using Ollix.Domain.Aggregates.OrderAggregate;
using Ollix.Domain.Aggregates.PropellerAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate.Models;
using Ollix.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Application.UseCases.Propellers.Queries.GetPropellersByAddress
{
    public sealed record GetPropellersByAddressQuery(
        UserInfo UserInfo,
        Guid ClientId,
        Guid AddressId,
        Guid OrderId,
        bool? Active,
        bool? Installed,
        PaginationRequest PaginationRequest) : IRequest<Result<PaginationResponse<Propeller>>>;
}
