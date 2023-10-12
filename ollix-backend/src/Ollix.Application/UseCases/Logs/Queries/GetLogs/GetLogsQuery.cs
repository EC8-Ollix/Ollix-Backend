using Ardalis.Result;
using MediatR;
using Ollix.Application.Shared;
using Ollix.Domain.Aggregates.ClientAppAggregate;
using Ollix.Domain.Aggregates.LogAggregate;
using Ollix.Domain.Aggregates.LogAppAggregate.Models;
using Ollix.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Application.UseCases.Logs.Queries.GetLogs
{
    public sealed record GetLogsQuery(UserInfo UserInfo, Guid ClientId, PaginationRequest PaginationRequest)
        : IRequest<Result<PaginationResponse<LogAppModel>>>;
}
