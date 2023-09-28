using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Ollix.API.Shared;
using Ollix.Application.Authentication.Commands.Register;
using Swashbuckle.AspNetCore.Annotations;

namespace Ollix.API.Endpoints.Authentication
{
    public class Register : EndpointBaseAsync
            .WithRequest<RegisterRequest>
            .WithActionResult<RegisterResponse>
    {
        protected readonly IMediator _mediator;
        public Register(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Routes.RegisterUri)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(RegisterResponse))]
        [SwaggerOperation(
          Summary = "Registrar na plataforma",
          Description = "Realiza registro do usuário e empresa na plataforma",
          OperationId = "authentication.register"
        )]
        public override async Task<ActionResult<RegisterResponse>> HandleAsync([FromBody] RegisterRequest request,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(request.ToCommand(), cancellationToken);

            return result.Handle()
                        .OnSuccess(r => Created(Routes.RegisterUri, new RegisterResponse(r)))
                        .OnError(errors => BadRequest(result.Errors))
                        .OnInvalid(errors => BadRequest(result.ValidationErrors))
                        .Return();
        }
    }
}
