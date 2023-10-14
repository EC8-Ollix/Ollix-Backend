using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Ollix.API.Shared;
using Ollix.Application.UseCases.Orders.Queries.GetOrderById;
using Ollix.Application.UseCases.Users.Queries.GetUserById;
using Ollix.Domain.Aggregates.OrderAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using Ollix.SharedKernel.Extensions;

namespace Ollix.API.Endpoints.Orders
{
    [Authorize]
    public class GetOrderById : EndpointBaseAsync
            .WithRequest<Guid>
            .WithActionResult<Order>
    {
        protected readonly IMediator _mediator;

        public GetOrderById(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Routes.OrdersUri + "/{orderId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Order))]
        [SwaggerOperation(
          Summary = "Obter um Pedido por Id",
          Description = "Retorna o Pedido encontrado pelo Id",
          OperationId = "orders.getbyid",
          Tags = new[] { "Pedidos" }
        )]
        public override async Task<ActionResult<Order>> HandleAsync([Required] Guid orderId,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetOrderByIdQuery(orderId), cancellationToken);

            return result.Handle()
                        .OnSuccess(resultValue => Ok(resultValue))
                        .OnNotFound(errors => NotFound(result.ToErrorModel()))
                        .OnError(errors => BadRequest(result.ToErrorModel()))
                        .Return();
        }
    }
}
