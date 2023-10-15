using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ollix.API.Shared;
using Ollix.Domain.Aggregates.OrderAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate;
using Ollix.SharedKernel.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace Ollix.API.Endpoints.Orders
{
    [Authorize(Roles = nameof(UserType.Admin))]
    public class ProcessOrder : EndpointBaseAsync
        .WithRequest<ProcessOrderRequest>
        .WithActionResult<Order>
    {
        protected readonly IMediator _mediator;

        public ProcessOrder(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPatch(Routes.OrdersUri + "/{orderId}/process")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Order))]
        [SwaggerOperation(
          Summary = "Processa um pedido feito pelo Cliente",
          Description = "Cancela a solicitação de Hélice feita pelo Cliente",
          OperationId = "orders.processorder",
          Tags = new[] { "Pedidos" }
        )]
        public override async Task<ActionResult<Order>> HandleAsync(ProcessOrderRequest request,
            CancellationToken cancellationToken = default)
        {
            var userInfo = ApplicationClaims.GetUserInfoByClaims(User.Claims.ToArray());
            var command = request.ToCommand();
            command.UserInfo = userInfo;

            var result = await _mediator.Send(command, cancellationToken);

            return result.Handle()
                        .OnSuccess(resultValue => Ok(resultValue))
                        .OnNotFound(errors => NotFound(result.ToErrorModel()))
                        .OnInvalid(errors => BadRequest(result.ToErrorModel()))
                        .OnError(errors => BadRequest(result.ToErrorModel()))
                        .Return();
        }
    }
}
