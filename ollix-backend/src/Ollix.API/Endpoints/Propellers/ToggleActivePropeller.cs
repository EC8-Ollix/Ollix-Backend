using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Ollix.API.Shared;
using Ollix.Application.UseCases.Propellers.Queries.GetPropellerById;
using Ollix.Domain.Aggregates.PropellerAggregate;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using Ollix.SharedKernel.Extensions;
using Ollix.Application.UseCases.Propellers.Commands.TogglePropeller;

namespace Ollix.API.Endpoints.Propellers
{
    [Authorize]
    public class ToggleActivePropeller : EndpointBaseAsync
            .WithRequest<Guid>
            .WithoutResult
    {
        protected readonly IMediator _mediator;

        public ToggleActivePropeller(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPatch(Routes.PropellersUri + "/{propellerId}/toggle")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [SwaggerOperation(
          Summary = "Ativa/Desativa uma Hélice pelo Id",
          Description = "Ativa/Desativa uma Hélice pelo Id",
          OperationId = "propellers.toggle",
          Tags = new[] { "Helices" }
        )]
        public override async Task<ActionResult> HandleAsync([Required] Guid propellerId,
            CancellationToken cancellationToken = default)
        {
            var userInfo = ApplicationClaims.GetUserInfoByClaims(User.Claims.ToArray());
            var result = await _mediator.Send(new TogglePropellerCommand(userInfo!, propellerId), cancellationToken);

            return result.Handle()
                        .OnSuccess(resultValue => NoContent())
                        .OnNotFound(errors => NotFound(result.ToErrorModel()))
                        .OnError(errors => BadRequest(result.ToErrorModel()))
                        .Return();
        }
    }
}
