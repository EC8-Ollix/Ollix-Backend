using Ardalis.ApiEndpoints;
using Ardalis.Result;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Ollix.API.Shared;
using Ollix.Application.UseCases.Propellers.Queries.GetAdressesFromPropellers;
using Ollix.Application.UseCases.Propellers.Queries.GetPropellersByAddress;
using Ollix.Domain.Aggregates.AddressAppAggregate.Models;
using Ollix.Domain.Aggregates.PropellerAggregate;
using Ollix.Domain.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Ollix.API.Endpoints.Propellers
{
    [Authorize]
    public class GetPropellersByAddress : EndpointBaseAsync
        .WithRequest<GetPropellersByAddressRequest>
        .WithActionResult<PaginationResponse<Propeller>>
    {
        protected readonly IMediator _mediator;

        public GetPropellersByAddress(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Routes.PropellersUri + "/by-address")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponse<Propeller>))]
        [SwaggerOperation(
          Summary = "Obter as Hélices por um endereço",
          Description = "Retorna os Pedidos realizados, por Cliente (Obrigatório para Admins), status e Data de Solicitação",
          OperationId = "propellers.getbyaddress",
          Tags = new[] { "Helices" }
        )]
        public override async Task<ActionResult<PaginationResponse<Propeller>>> HandleAsync(GetPropellersByAddressRequest request,
            CancellationToken cancellationToken = default)
        {
            var userInfo = ApplicationClaims.GetUserInfoByClaims(User.Claims.ToArray());

            var query = new GetPropellersByAddressQuery(
                userInfo!,
                request.ClientId,
                request.AddressId,
                request.OrderId,
                request.Active,
                request.Installed,
                request.PaginationRequest!);

            var result = await _mediator.Send(query, cancellationToken);

            return Ok(result.Value);
        }
    }
}
