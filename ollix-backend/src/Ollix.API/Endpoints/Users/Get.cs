using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ollix.API.Shared;
using Ollix.Application.Shared;
using Ollix.Application.UseCases.Users.Queries.GetUsers;
using Ollix.Domain.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Ollix.API.Endpoints.Users
{
    [Authorize]
    public class Get : EndpointBaseAsync
                .WithRequest<PaginationRequest>
                .WithActionResult<PaginationResponse<UserInfo>>
    {
        protected readonly IMediator _mediator;

        public Get(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Routes.UsersUri)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(
          Summary = "Obter Usuários",
          Description = "Retorna os Usuários cadastrados",
          OperationId = "usuarios.get",
          Tags = new[] { "Usuarios" }
        )]
        public override async Task<ActionResult<PaginationResponse<UserInfo>>> HandleAsync(PaginationRequest paginationRequest,
            CancellationToken cancellationToken = default)
        {
            var query = new GetUsersQuery(paginationRequest);

            var result = await _mediator.Send(query, cancellationToken);

            return Ok(result.Value);
        }
    }
}
