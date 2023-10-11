using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Ollix.API.Shared;
using Ollix.Application.Shared;
using Ollix.SharedKernel.Extensions;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Ollix.API.Endpoints.Users
{
    [Authorize]
    public class UpdateUser : EndpointBaseAsync
        .WithRequest<UpdateUserRequest>
        .WithoutResult
    {
        protected readonly IMediator _mediator;
        public UpdateUser(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut(Routes.UsersUri + "/{userId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [SwaggerOperation(
          Summary = "Atualiza um Usuário na Plataforma",
          Description = "Atualiza as Infos de um Usuário na Plataforma",
          OperationId = "users.updateuser",
          Tags = new[] { "Usuarios" }
        )]
        public override async Task<ActionResult> HandleAsync(UpdateUserRequest request,
            CancellationToken cancellationToken = default)
        {
            var command = request.ToCommand();
            command.UserInfo = ApplicationClaims.GetUserInfoByClaims(User.Claims.ToArray());
            command.UserId = request.UserId;

            var result = await _mediator.Send(command, cancellationToken);

            return result.Handle()
                        .OnSuccess(resultValue => NoContent())
                        .OnNotFound(errors => NotFound(result.ToErrorModel()))
                        .OnError(errors => BadRequest(result.ToErrorModel()))
                        .OnInvalid(errors => BadRequest(result.ToErrorModel()))
                        .Return();
        }
    }
}
