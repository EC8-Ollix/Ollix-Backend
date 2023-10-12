using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ollix.API.Shared;
using Ollix.Application.UseCases.Clients.Queries.GetClients;
using Ollix.Domain.Aggregates.ClientAppAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate.Models;
using Ollix.Domain.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Ollix.API.Endpoints.Clients
{
    [Authorize(Roles = nameof(UserType.Admin))]
    public class GetClients : EndpointBaseAsync
            .WithRequest<GetClientsRequest>
            .WithActionResult<PaginationResponse<ClientApp>>
    {
        protected readonly IMediator _mediator;

        public GetClients(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Routes.ClientsUri)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponse<UserInfo>))]
        [SwaggerOperation(
          Summary = "Obter Clientes",
          Description = "Retorna os Clientes cadastrados na plataforma",
          OperationId = "clients.get",
          Tags = new[] { "Clientes" }
        )]
        public override async Task<ActionResult<PaginationResponse<ClientApp>>> HandleAsync(GetClientsRequest getClientsRequest,
            CancellationToken cancellationToken = default)
        {
            var userInfo = ApplicationClaims.GetUserInfoByClaims(User.Claims.ToArray());
            var result = await _mediator.Send(new GetClientsQuery(userInfo!, getClientsRequest.PaginationRequest!), cancellationToken);

            return Ok(result.Value);
        }
    }
}
