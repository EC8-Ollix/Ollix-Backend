using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Ollix.API.Shared;
using Ollix.Application.Shared;
using Ollix.Application.UseCases.Clients.Queries.GetClientById;
using Ollix.Application.UseCases.Clients.Queries.GetClients;
using Ollix.Domain.Aggregates.ClientAppAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate;
using Ollix.Domain.Models;
using Ollix.SharedKernel.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace Ollix.API.Endpoints.Clients
{
    [Authorize(Roles = nameof(UserType.Admin))]
    public class GetClientById : EndpointBaseAsync
        .WithRequest<Guid>
        .WithActionResult<ClientApp>
    {
        protected readonly IMediator _mediator;

        public GetClientById(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Routes.ClientsUri + "/{clientId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClientApp))]
        [SwaggerOperation(
          Summary = "Obter um Cliente por Id",
          Description = "Retorna um Cliente pelo Id",
          OperationId = "clients.getbyid",
          Tags = new[] { "Clientes" }
        )]
        public override async Task<ActionResult<ClientApp>> HandleAsync(Guid clientId,
            CancellationToken cancellationToken = default)
        {
            var userInfo = ApplicationClaims.GetUserInfoByClaims(User.Claims.ToArray());
            var result = await _mediator.Send(new GetClientByIdQuery(userInfo!, clientId), cancellationToken);

            return result.Handle()
                .OnSuccess(resultValue => Ok(resultValue))
                .OnNotFound(errors => NotFound(result.ToErrorModel()))
                .Return();
        }
    }
}
