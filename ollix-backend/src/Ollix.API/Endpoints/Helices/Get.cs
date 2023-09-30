using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Ollix.API.Endpoints.Authentication;
using Ollix.API.Shared;
using Ollix.Application.UseCases.Authentication.Shared;
using Ollix.Domain.UserAggregate;
using Ollix.SharedKernel.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace Ollix.API.Endpoints.Helices
{
    [Authorize]
    public class Get : EndpointBaseAsync
            .WithoutRequest
            .WithoutResult
    {
        public Get() { }

        [HttpPost(Routes.HelicesUri)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(
          Summary = "Obter Hélices",
          Description = "Retorna as Hélices cadastradas do cliente",
          OperationId = "helices.get",
          Tags = new[] { "Helices" }
        )]
        public override async Task<ActionResult> HandleAsync(CancellationToken cancellationToken = default)
        {
            var helices = new object[]
            {
                new 
                {
                    Id = 1,
                    Nome = "Hélice 1" 
                }
            };

            return Ok(helices);
        }
    }
}
