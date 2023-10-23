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
        private readonly IMediator _mediator;

        public GetLogsQueryHandler(IRepository<LogApp> repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<Result<PaginationResponse<LogAppModel>>> Handle(GetLogsQuery query,
            CancellationToken cancellationToken)
        {
            var clientId = query.ClientId != Guid.Empty ? query.ClientId : query.UserInfo.ClientApp!.Id;

            var logsCount = await _repository.CountAsync(new LogsSpec(clientId), cancellationToken);
            var logsResult = await _repository.ListAsync(new LogsSpec(query.PaginationRequest, clientId), cancellationToken);

            return Result.Success(new PaginationResponse<LogAppModel>(logsResult, logsCount, query.PaginationRequest));
        }
    }
}
