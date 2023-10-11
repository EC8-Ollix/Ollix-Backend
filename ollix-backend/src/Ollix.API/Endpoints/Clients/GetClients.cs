using Ardalis.ApiEndpoints;
using Ardalis.Result;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Ollix.API.Endpoints.Users;
using Ollix.API.Shared;
using Ollix.Application.Shared;
using Ollix.Application.UseCases.Clients.Queries.GetClients;
using Ollix.Application.UseCases.Users.Queries.GetUsers;
using Ollix.Domain.Aggregates.ClientAppAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate;
using Ollix.Domain.Models;
using Ollix.SharedKernel.Extensions;
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
        public override async Task<ActionResult<PaginationResponse<ClientApp>>> HandleAsync([FromQuery] GetClientsRequest getClientsRequest,
            CancellationToken cancellationToken = default)
        {
            var userInfo = ApplicationClaims.GetUserInfoByClaims(User.Claims.ToArray());
            var result = await _mediator.Send(new GetClientsQuery(userInfo!, getClientsRequest.PaginationRequest!), cancellationToken);

            return Ok(result.Value);
        }
    }
}
