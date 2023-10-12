using Ardalis.ApiEndpoints;
using Ardalis.Result;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ollix.API.Shared;
using Ollix.Application.Shared;
using Ollix.Application.UseCases.Users.Queries.GetUsers;
using Ollix.Domain.Models;
using Ollix.SharedKernel.Extensions;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;

namespace Ollix.API.Endpoints.Users
{
    [Authorize]
    public class GetUsers : EndpointBaseAsync
                .WithRequest<GetUsersRequest>
                .WithActionResult<PaginationResponse<UserInfo>>
    {
        protected readonly IMediator _mediator;

        public GetUsers(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Routes.UsersUri)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponse<UserInfo>))]
        [SwaggerOperation(
          Summary = "Obter Usuários",
          Description = "Retorna os Usuários cadastrados",
          OperationId = "users.get",
          Tags = new[] { "Usuarios" }
        )]
        public override async Task<ActionResult<PaginationResponse<UserInfo>>> HandleAsync(GetUsersRequest getUsersRequest,
            CancellationToken cancellationToken = default)
        {
            if (getUsersRequest.ClientId!.IsInvalidGuid(out Guid clientId))
                return BadRequest(Result.Error("Informe um Cliente Válido!").ToErrorModel());

            var userInfo = ApplicationClaims.GetUserInfoByClaims(User.Claims.ToArray());
            var result = await _mediator.Send(new GetUsersQuery(userInfo!, clientId, getUsersRequest.PaginationRequest!), cancellationToken);

            return Ok(result.Value);
        }
    }
}
