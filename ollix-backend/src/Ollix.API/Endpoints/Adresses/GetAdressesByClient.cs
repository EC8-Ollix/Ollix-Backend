using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Ollix.API.Endpoints.Propellers;
using Ollix.API.Shared;
using Ollix.Application.UseCases.Adresses.Queries.GetAdressesByClient;
using Ollix.Application.UseCases.Propellers.Queries.GetAdressesFromPropellers;
using Ollix.Domain.Aggregates.AddressAppAggregate;
using Ollix.Domain.Aggregates.AddressAppAggregate.Models;
using Ollix.Domain.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Ollix.API.Endpoints.Adresses
{
    [Authorize]
    public class GetAdressesByClient : EndpointBaseAsync
        .WithRequest<Guid>
        .WithActionResult<AddressApp[]>
    {
        protected readonly IMediator _mediator;

        public GetAdressesByClient(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Routes.AdressesUri)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddressApp[]))]
        [SwaggerOperation(
          Summary = "Obter os Endereços utilizados pelo Cliente",
          Description = "Obter os Endereços utilizados pelo Cliente",
          OperationId = "adresses.get",
          Tags = new[] { "Enderecos" }
        )]
        public override async Task<ActionResult<AddressApp[]>> HandleAsync([FromQuery] Guid clientId,
            CancellationToken cancellationToken = default)
        {
            var userInfo = ApplicationClaims.GetUserInfoByClaims(User.Claims.ToArray());
            var result = await _mediator.Send(new GetAdressesByClientQuery(userInfo!, clientId), cancellationToken);

            return Ok(result.Value);
        }
    }
}
