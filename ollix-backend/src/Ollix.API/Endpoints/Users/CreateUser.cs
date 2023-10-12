using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ollix.API.Shared;
using Ollix.Domain.Aggregates.UserAppAggregate.Models;
using Ollix.SharedKernel.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace Ollix.API.Endpoints.Users
{
    [Authorize]
    public class CreateUser : EndpointBaseAsync
            .WithRequest<CreateUserRequest>
            .WithActionResult<UserInfo>
    {
        protected readonly IMediator _mediator;
        public CreateUser(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Routes.UsersUri)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserInfo))]
        [SwaggerOperation(
          Summary = "Cria um Usuário na Plataforma",
          Description = "Cria um Usuário na Plataforma, para a base do Cliente logado",
          OperationId = "users.createuser",
          Tags = new[] { "Usuarios" }
        )]
        public override async Task<ActionResult<UserInfo>> HandleAsync([FromBody] CreateUserRequest request,
            CancellationToken cancellationToken = default)
        {
            var command = request.ToCommand();
            command.UserInfo = ApplicationClaims.GetUserInfoByClaims(User.Claims.ToArray());

            var result = await _mediator.Send(command, cancellationToken);

            return result.Handle()
                        .OnSuccess(resultValue => Created($"{Routes.RegisterUri}/{resultValue.Id}", resultValue))
                        .OnError(errors => BadRequest(result.ToErrorModel()))
                        .OnInvalid(errors => BadRequest(result.ToErrorModel()))
                        .Return();
        }
    }
}
