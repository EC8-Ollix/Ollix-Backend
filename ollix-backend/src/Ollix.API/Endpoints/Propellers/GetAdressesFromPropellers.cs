using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ollix.API.Shared;
using Ollix.Application.UseCases.Propellers.Queries.GetAdressesFromPropellers;
using Ollix.Domain.Aggregates.AddressAppAggregate.Models;
using Ollix.Domain.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Ollix.API.Endpoints.Propellers
{
    [Authorize]
    public class GetAdressesFromPropellers : EndpointBaseAsync
            .WithRequest<GetAdressesFromPropellersRequest>
            .WithActionResult<PaginationResponse<AddressPropellerModel>>
    {
        protected readonly IMediator _mediator;

        public GetAdressesFromPropellers(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Routes.PropellersUri + "/propeller-adresses")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponse<AddressPropellerModel>))]
        [SwaggerOperation(
          Summary = "Obter os Endereços de Hélices cadastradas",
          Description = "Retorna os Pedidos realizados, por Cliente (Obrigatório para Admins), status e Data de Solicitação",
          OperationId = "propellers.getadressesfrompropellers",
          Tags = new[] { "Helices" }
        )]
        public override async Task<ActionResult<PaginationResponse<AddressPropellerModel>>> HandleAsync(GetAdressesFromPropellersRequest request,
            CancellationToken cancellationToken = default)
        {
            var userInfo = ApplicationClaims.GetUserInfoByClaims(User.Claims.ToArray());
            var query = new GetAdressesFromPropellersQuery(
                userInfo!,
                request.ClientId,
                request.State,
                request.City,
                request.PaginationRequest!);

            var result = await _mediator.Send(query, cancellationToken);

            return Ok(result.Value);
        }
    }
}
