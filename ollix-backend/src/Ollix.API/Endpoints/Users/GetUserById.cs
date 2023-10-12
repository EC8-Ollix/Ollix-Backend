using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ollix.API.Shared;
using Ollix.Application.UseCases.Users.Queries.GetUserById;
using Ollix.Domain.Aggregates.UserAppAggregate.Models;
using Ollix.SharedKernel.Extensions;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Ollix.API.Endpoints.Users
{
    [Authorize]
    public class GetUserById : EndpointBaseAsync
            .WithRequest<Guid>
            .WithActionResult<UserInfo>
    {
        protected readonly IMediator _mediator;

        public GetUserById(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Routes.UsersUri + "/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserInfo))]
        [SwaggerOperation(
          Summary = "Obter um Usuário por Id",
          Description = "Retorna o Usuário encontrado pelo Id",
          OperationId = "users.getbyid",
          Tags = new[] { "Usuarios" }
        )]
        public override async Task<ActionResult<UserInfo>> HandleAsync([Required] Guid userId,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetUserByIdQuery(userId), cancellationToken);

            return result.Handle()
                        .OnSuccess(resultValue => Ok(new UserInfo(resultValue)))
                        .OnNotFound(errors => NotFound(result.ToErrorModel()))
                        .OnError(errors => BadRequest(result.ToErrorModel()))
                        .Return();
        }
    }
}
