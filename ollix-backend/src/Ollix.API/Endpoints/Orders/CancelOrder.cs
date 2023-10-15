using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ollix.API.Shared;
using Ollix.Application.UseCases.Orders.Commands.CancelOrder;
using Ollix.Domain.Aggregates.UserAppAggregate;
using Ollix.SharedKernel.Extensions;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Ollix.API.Endpoints.Orders
{
    [Authorize(Roles = nameof(UserType.Client))]
    public class CancelOrder : EndpointBaseAsync
        .WithRequest<Guid>
        .WithoutResult
    {
        protected readonly IMediator _mediator;

        public CancelOrder(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPatch(Routes.OrdersUri + "/{orderId}/cancel")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [SwaggerOperation(
          Summary = "Cancela um pedido feito pelo Cliente",
          Description = "Cancela a solicitação de Hélice feita pelo Cliente",
          OperationId = "orders.cancelorder",
          Tags = new[] { "Pedidos" }
        )]
        public override async Task<ActionResult> HandleAsync([Required] Guid orderId,
            CancellationToken cancellationToken = default)
        {
            var userInfo = ApplicationClaims.GetUserInfoByClaims(User.Claims.ToArray());
            var result = await _mediator.Send(new CancelOrderCommand(userInfo!, orderId), cancellationToken);

            return result.Handle()
                        .OnSuccess(resultValue => NoContent())
                        .OnNotFound(errors => NotFound(result.ToErrorModel()))
                        .OnError(errors => BadRequest(result.ToErrorModel()))
                        .Return();
        }
    }
}
