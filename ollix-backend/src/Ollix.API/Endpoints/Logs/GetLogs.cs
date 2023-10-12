using Ardalis.ApiEndpoints;
using Ardalis.Result;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ollix.API.Shared;
using Ollix.Application.UseCases.Logs.Queries.GetLogs;
using Ollix.Domain.Aggregates.LogAppAggregate.Models;
using Ollix.Domain.Models;
using Ollix.SharedKernel.Extensions;
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
            if (getLogsRequest.ClientId!.IsInvalidGuid(out Guid clientId))
                return BadRequest(Result.Error("Informe um Cliente Válido!").ToErrorModel());

            var userInfo = ApplicationClaims.GetUserInfoByClaims(User.Claims.ToArray());
            var result = await _mediator.Send(new GetLogsQuery(userInfo!, clientId, getLogsRequest.PaginationRequest!), cancellationToken);

            return Ok(result.Value);
        }
    }
}
