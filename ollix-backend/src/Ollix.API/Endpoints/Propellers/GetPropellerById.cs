using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ollix.API.Shared;
using Ollix.Application.UseCases.Propellers.Queries.GetPropellerById;
using Ollix.Domain.Aggregates.PropellerAggregate;
using Ollix.SharedKernel.Extensions;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Ollix.API.Endpoints.Propellers
{
    [Authorize]
    public class GetPropellerById : EndpointBaseAsync
            .WithRequest<Guid>
            .WithActionResult<Propeller>
    {
        protected readonly IMediator _mediator;

        public GetPropellerById(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Routes.PropellersUri + "/{propellerId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Propeller))]
        [SwaggerOperation(
          Summary = "Obter uma Hélice pelo Id",
          Description = "Retorna a Hélice encontrada pelo Id",
          OperationId = "propellers.getbyid",
          Tags = new[] { "Helices" }
        )]
        public override async Task<ActionResult<Propeller>> HandleAsync([Required] Guid propellerId,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetPropellerByIdQuery(propellerId), cancellationToken);

            return result.Handle()
                        .OnSuccess(resultValue => Ok(resultValue))
                        .OnNotFound(errors => NotFound(result.ToErrorModel()))
                        .OnError(errors => BadRequest(result.ToErrorModel()))
                        .Return();
        }
    }
}
