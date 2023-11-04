using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ollix.API.Shared;
using Ollix.SharedKernel.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace Ollix.API.Endpoints.Users
{
    [Authorize]
    public class ChangePassword : EndpointBaseAsync
        .WithRequest<ChangePasswordRequest>
        .WithoutResult
    {
        protected readonly IMediator _mediator;
        public ChangePassword(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut(Routes.UsersUri+ "/changepassword" + "/{userId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [SwaggerOperation(
          Summary = "Atualiza a senha do usuário na Plataforma",
          Description = "Atualiza a senha de um Usuário na Plataforma",
          OperationId = "users.changepassword",
          Tags = new[] { "Usuarios" }
        )]
        public override async Task<ActionResult> HandleAsync(ChangePasswordRequest request,
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
