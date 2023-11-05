using Ardalis.Result;
using MediatR;
using Ollix.Domain.Aggregates.LogAggregate;
using Ollix.Domain.Aggregates.LogAppAggregate.Models;
using Ollix.Domain.Aggregates.LogAppAggregate.Specifications;
using Ollix.Domain.Models;
using Ollix.SharedKernel.Interfaces;

namespace Ollix.Application.UseCases.Logs.Queries.GetLogs
{
    public sealed class GetLogsQueryHandler : IRequestHandler<GetLogsQuery, Result<PaginationResponse<LogAppModel>>>
    {
        private readonly IRepository<LogApp> _repository;

        public GetLogsQueryHandler(IRepository<LogApp> repository)
        {
            _repository = repository;
        }

        public async Task<Result<PaginationResponse<LogAppModel>>> Handle(GetLogsQuery query,
            CancellationToken cancellationToken)
        {
            var clientId = query.ClientId != Guid.Empty ? query.ClientId : query.UserInfo.ClientApp!.Id;

            var logsSpec = new LogsSpec();

            logsSpec.WithBaseSpec(clientId, query.Entity, query.Operation, query.UserName, query.Date);
            var logsCount = await _repository.CountAsync(logsSpec, cancellationToken);

            logsSpec.WithPagination(query.PaginationRequest);
            var logsResult = await _repository.ListAsync(logsSpec, cancellationToken);

            return Result.Success(new PaginationResponse<LogAppModel>(logsResult, logsCount, query.PaginationRequest));
        }
    }
}
