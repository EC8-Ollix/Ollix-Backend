using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ollix.API.Shared;
using Ollix.Application.UseCases.Users.Commands.DeleteUser;
using Ollix.SharedKernel.Extensions;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Ollix.API.Endpoints.Users
{
    [Authorize]
    public class DeleteUser : EndpointBaseAsync
        .WithRequest<Guid>
        .WithoutResult
    {
        protected readonly IMediator _mediator;

        public DeleteUser(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpDelete(Routes.UsersUri + "/{userId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [SwaggerOperation(
          Summary = "Exclui um Usuário pelo Id",
          Description = "Exclui o Usuário da Base",
          OperationId = "users.deleteuser",
          Tags = new[] { "Usuarios" }
        )]
        public override async Task<ActionResult> HandleAsync([Required] Guid userId,
            CancellationToken cancellationToken = default)
        {
            var userInfo = ApplicationClaims.GetUserInfoByClaims(User.Claims.ToArray());
            var result = await _mediator.Send(new DeleteUserCommand(userInfo!, userId), cancellationToken);

            return result.Handle()
                        .OnSuccess(resultValue => NoContent())
                        .OnNotFound(errors => NotFound(result.ToErrorModel()))
                        .OnError(errors => BadRequest(result.ToErrorModel()))
                        .Return();
        }
    }
}
