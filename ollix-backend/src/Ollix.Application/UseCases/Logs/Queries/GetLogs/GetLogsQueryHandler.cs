using Ardalis.Result;
using MediatR;
using Ollix.Application.UseCases.Clients.Queries.GetClientById;
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
            var clientAppResult = await _mediator.Send(new GetClientByIdQuery(query.UserInfo, query.ClientId), cancellationToken);
            if (!clientAppResult.IsSuccess)
                return Result.Error(clientAppResult.Errors.ToArray());

            var logsCount = await _repository.CountAsync(new LogsSpec(clientAppResult.Value), cancellationToken);
            var logsResult = await _repository.ListAsync(new LogsSpec(query.PaginationRequest, clientAppResult.Value), cancellationToken);

            return Result.Success(new PaginationResponse<LogAppModel>(logsResult, logsCount, query.PaginationRequest));
        }
    }
}
