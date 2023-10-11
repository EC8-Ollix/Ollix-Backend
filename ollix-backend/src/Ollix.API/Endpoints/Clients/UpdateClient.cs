using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Ollix.API.Endpoints.Users;
using Ollix.API.Shared;
using Ollix.SharedKernel.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace Ollix.API.Endpoints.Clients
{
    [Authorize]
    public class UpdateClient : EndpointBaseAsync
        .WithRequest<UpdateClientRequest>
        .WithoutResult
    {
        protected readonly IMediator _mediator;
        public UpdateClient(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut(Routes.ClientsUri + "/{clientId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [SwaggerOperation(
          Summary = "Atualiza um Cliente",
          Description = "Atualiza as Infos de um cliente na Plataforma",
          OperationId = "clients.updateclient",
          Tags = new[] { "Clientes" }
        )]
        public override async Task<ActionResult> HandleAsync(UpdateClientRequest request,
            CancellationToken cancellationToken = default)
        {
            var command = request.ToCommand();
            command.UserInfo = ApplicationClaims.GetUserInfoByClaims(User.Claims.ToArray());
            command.ClientId = request.ClientId;

            var result = await _mediator.Send(command, cancellationToken);

            return result.Handle()
                        .OnSuccess(resultValue => NoContent())
                        .OnNotFound(errors => NotFound(result.ToErrorModel()))
                        .OnError(errors => BadRequest(result.ToErrorModel()))
                        .OnInvalid(errors => BadRequest(result.ToErrorModel()))
                        .Return();
        }
    }
}
