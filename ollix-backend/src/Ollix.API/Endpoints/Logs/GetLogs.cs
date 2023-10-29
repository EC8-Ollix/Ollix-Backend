using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ollix.API.Shared;
using Ollix.Application.UseCases.Logs.Queries.GetLogs;
using Ollix.Domain.Aggregates.LogAppAggregate.Models;
using Ollix.Domain.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Ollix.API.Endpoints.Logs
{
    [Authorize]
    public class GetLogs : EndpointBaseAsync
            .WithRequest<GetLogsRequest>
            .WithActionResult<PaginationResponse<LogAppModel>>
    {
        protected readonly IMediator _mediator;

        public GetLogs(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Routes.LogsUri)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponse<LogAppModel>))]
        [SwaggerOperation(
          Summary = "Obter Logs de um Cliente",
          Description = "Retorna os Logs de um Cliente especifico, ou do cliente do usuário logado",
          OperationId = "logs.get",
          Tags = new[] { "Logs" }
        )]
        public override async Task<ActionResult<PaginationResponse<LogAppModel>>> HandleAsync(GetLogsRequest getLogsRequest,
            CancellationToken cancellationToken = default)
        {
            var userInfo = ApplicationClaims.GetUserInfoByClaims(User.Claims.ToArray());
            var query = new GetLogsQuery(
                userInfo!, 
                getLogsRequest.ClientId, 
                getLogsRequest.Entity,
                getLogsRequest.Operation,
                getLogsRequest.UserName,
                new DateTimeOffset[] { getLogsRequest.RequestedDateFrom, getLogsRequest.RequestedDateTo },
                getLogsRequest.PaginationRequest!);


            var result = await _mediator.Send(query, cancellationToken);

            return Ok(result.Value);
        }
    }
}
