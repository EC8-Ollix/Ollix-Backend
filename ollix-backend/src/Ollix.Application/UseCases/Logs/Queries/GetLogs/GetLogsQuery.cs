using Ardalis.Result;
using MediatR;
using Ollix.Domain.Aggregates.LogAggregate;
using Ollix.Domain.Aggregates.LogAppAggregate.Models;
using Ollix.Domain.Aggregates.UserAppAggregate.Models;
using Ollix.Domain.Models;

namespace Ollix.Application.UseCases.Logs.Queries.GetLogs
{
    public sealed record GetLogsQuery(
        UserInfo UserInfo, 
        Guid ClientId, 
        EntityEnum? Entity,
        OperationEnum? Operation,
        string? UserName,
        DateTimeOffset[]? Date,
        PaginationRequest PaginationRequest)
        : IRequest<Result<PaginationResponse<LogAppModel>>>;
}
