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
    [Authorize(Roles = nameof(UserType.Client))]
    public class CreateOrder : EndpointBaseAsync
        .WithRequest<CreateOrderRequest>
        .WithActionResult<Order>
    {
        protected readonly IMediator _mediator;
        public CreateOrder(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Routes.OrdersUri)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Order))]
        [SwaggerOperation(
          Summary = "Solicita um Pedido de Hélices",
          Description = "Solicita um Pedido de Hélices na Plataforma",
          OperationId = "orders.createorder",
          Tags = new[] { "Pedidos" }
        )]
        public override async Task<ActionResult<Order>> HandleAsync([FromBody] CreateOrderRequest request,
            CancellationToken cancellationToken = default)
        {
            var command = request.ToCommand();
            command.UserInfo = ApplicationClaims.GetUserInfoByClaims(User.Claims.ToArray());

            var result = await _mediator.Send(command, cancellationToken);

            return result.Handle()
                        .OnSuccess(resultValue => Created($"{Routes.OrdersUri}/{resultValue.Id}", resultValue))
                        .OnError(errors => BadRequest(result.ToErrorModel()))
                        .OnInvalid(errors => BadRequest(result.ToErrorModel()))
                        .Return();
        }
    }
}
