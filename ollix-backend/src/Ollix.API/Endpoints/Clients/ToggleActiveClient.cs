using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Ollix.API.Shared;
using Ollix.Application.UseCases.Clients.Commands.ToggleClient;
using Ollix.Application.UseCases.Propellers.Commands.TogglePropeller;
using Ollix.Domain.Aggregates.PropellerAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using Ollix.SharedKernel.Extensions;

namespace Ollix.API.Endpoints.Clients
{
    [Authorize(Roles = nameof(UserType.Admin))]
    public class ToggleActiveClient : EndpointBaseAsync
        .WithRequest<Guid>
        .WithoutResult
    {
        protected readonly IMediator _mediator;

        public ToggleActiveClient(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPatch(Routes.ClientsUri + "/{clientId}/toggle")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [SwaggerOperation(
          Summary = "Ativa/Desativa um cliente pelo Id",
          Description = "Ativa/Desativa um cliente pelo Id",
          OperationId = "clients.toggle",
          Tags = new[] { "Clientes" }
        )]
        public override async Task<ActionResult> HandleAsync([Required] Guid clientId,
            CancellationToken cancellationToken = default)
        {
            var userInfo = ApplicationClaims.GetUserInfoByClaims(User.Claims.ToArray());
            var result = await _mediator.Send(new ToggleClientCommand(userInfo!, clientId), cancellationToken);

            return result.Handle()
                        .OnSuccess(resultValue => NoContent())
                        .OnNotFound(errors => NotFound(result.ToErrorModel()))
                        .OnError(errors => BadRequest(result.ToErrorModel()))
                        .Return();
        }
    }
}
