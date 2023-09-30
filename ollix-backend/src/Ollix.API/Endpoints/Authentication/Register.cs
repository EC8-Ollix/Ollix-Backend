using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ollix.API.Shared;
using Ollix.Application.UseCases.Authentication.Shared;
using Ollix.SharedKernel.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace Ollix.API.Endpoints.Authentication
{
    public class Register : EndpointBaseAsync
            .WithRequest<RegisterRequest>
            .WithActionResult<UserInfo>
    {
        protected readonly IMediator _mediator;
        public Register(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Routes.RegisterUri)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserInfo))]
        [SwaggerOperation(
          Summary = "Registrar na plataforma",
          Description = "Realiza registro do usuário e empresa na plataforma",
          OperationId = "authentication.register",
          Tags = new[] { "Authentication" }
        )]
        public override async Task<ActionResult<UserInfo>> HandleAsync([FromBody] RegisterRequest request,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(request.ToCommand(), cancellationToken);

            return result.Handle()
                        .OnSuccess(resultValue => Created(Routes.RegisterUri, resultValue))
                        .OnError(errors => BadRequest(result.ToErrorModel()))
                        .OnInvalid(errors => BadRequest(result.ToErrorModel()))
                        .Return();
        }
    }
}
