using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ollix.API.Shared;
using Ollix.Application.UseCases.Orders.Commands.ConfirmIntallation;
using Ollix.Domain.Aggregates.UserAppAggregate;
using Ollix.SharedKernel.Extensions;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Ollix.API.Endpoints.Orders
{
    [Authorize(Roles = nameof(UserType.Admin))]
    public class ConfirmOrderInstallation : EndpointBaseAsync
        .WithRequest<Guid>
        .WithActionResult
    {
        protected readonly IMediator _mediator;

        public ConfirmOrderInstallation(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPatch(Routes.OrdersUri + "/{orderId}/confirm-installation")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [SwaggerOperation(
          Summary = "Confirma a instalação de um pedido feito pelo Cliente",
          Description = "Confirma a instalação de um pedido feito pelo Cliente",
          OperationId = "orders.confirmorderinstallation",
          Tags = new[] { "Pedidos" }
        )]
        public override async Task<ActionResult> HandleAsync([Required] Guid orderId,
            CancellationToken cancellationToken = default)
        {
            var userInfo = ApplicationClaims.GetUserInfoByClaims(User.Claims.ToArray());
            var result = await _mediator.Send(new ConfirmInstallationCommand(orderId, userInfo!), cancellationToken);

            return result.Handle()
                        .OnSuccess(resultValue => NoContent())
                        .OnNotFound(errors => NotFound(result.ToErrorModel()))
                        .OnError(errors => BadRequest(result.ToErrorModel()))
                        .Return();
        }
    }
}
