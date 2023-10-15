using Ardalis.Result;
using MediatR;
using Ollix.Domain.Aggregates.AddressAppAggregate;
using Ollix.Domain.Aggregates.AddressAppAggregate.Models;
using Ollix.Domain.Aggregates.UserAppAggregate.Models;
using Ollix.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Application.UseCases.Adresses.Queries.GetAdressesByClient
{
    public sealed record GetAdressesByClientQuery(
        UserInfo UserInfo,
        Guid ClientId) : IRequest<Result<AddressApp[]>>;
}
