using Ardalis.Result;
using MediatR;
using Ollix.Domain.Aggregates.AddressAppAggregate.Models;
using Ollix.Domain.Aggregates.PropellerAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate.Models;
using Ollix.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Application.UseCases.Propellers.Queries.GetAdressesFromPropellers
{
    public sealed record GetAdressesFromPropellersQuery(
        UserInfo UserInfo,
        Guid ClientId,
        string? State,
        string? City,
        PaginationRequest PaginationRequest) : IRequest<Result<PaginationResponse<AddressPropellerModel>>>;
}
