using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ollix.API.Shared;
using Ollix.API.Shared.Request;
using Ollix.Domain.UserAggregate;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Ollix.API.Endpoints.Authentication
{
    public class Login : EndpointBaseAsync
            .WithRequest<LoginRequest>
            .WithActionResult<LoginResponse>
    {
        protected readonly IMediator _mediator;
        public Login(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Routes.LoginUri)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(LoginResponse))]
        [SwaggerOperation(
          Summary = "Autenticar na plataforma",
          Description = "Realiza Login na plataforma",
          OperationId = "authentication.login"
        )]
        public override async Task<ActionResult<LoginResponse>> HandleAsync([FromBody] LoginRequest request,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(request.ToCommand(), cancellationToken);

            return result.Handle()
                        .OnSuccess(r => Ok(new LoginResponse(r)))
                        .OnError(errors => BadRequest(result.Errors))
                        .OnInvalid(errors => BadRequest(result.ValidationErrors))
                        .Resolve();
        }
    }
}
