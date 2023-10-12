using Ardalis.Result;
using MediatR;
using Ollix.Application.Shared;
using Ollix.Domain.Aggregates.ClientAppAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate;
using Ollix.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Application.UseCases.Clients.Queries.GetClients
{
    public sealed record GetClientsQuery(UserInfo UserInfo, PaginationRequest PaginationRequest)
        : IRequest<Result<PaginationResponse<ClientApp>>>;
}
