using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Ollix.API.Shared;
using Ollix.Application.UseCases.Clients.Commands.DeleteClient;
using Ollix.SharedKernel.Extensions;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Ollix.API.Endpoints.Clients
{
    [Authorize]
    public class DeleteClient : EndpointBaseAsync
        .WithRequest<Guid>
        .WithoutResult
    {
        protected readonly IMediator _mediator;

        public DeleteClient(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpDelete(Routes.ClientsUri + "/{clientId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [SwaggerOperation(
          Summary = "Exclui um Cliente pelo Id",
          Description = "Exclui o Cliente da Base",
          OperationId = "clients.deleteuser",
          Tags = new[] { "Clientes" }
        )]
        public override async Task<ActionResult> HandleAsync([Required] Guid clientId,
            CancellationToken cancellationToken = default)
        {
            var userInfo = ApplicationClaims.GetUserInfoByClaims(User.Claims.ToArray());
            var result = await _mediator.Send(new DeleteClientCommand(userInfo!, clientId), cancellationToken);

            return result.Handle()
                        .OnSuccess(resultValue => NoContent())
                        .OnNotFound(errors => NotFound(result.ToErrorModel()))
                        .OnError(errors => BadRequest(result.ToErrorModel()))
                        .Return();
        }
    }
}
