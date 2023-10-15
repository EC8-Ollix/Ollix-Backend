using Ardalis.ApiEndpoints;
using Ardalis.Result;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Ollix.API.Endpoints.Users;
using Ollix.API.Shared;
using Ollix.Application.UseCases.Users.Queries.GetUsers;
using Ollix.Domain.Aggregates.OrderAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate.Models;
using Ollix.Domain.Models;
using Swashbuckle.AspNetCore.Annotations;
using Ollix.SharedKernel.Extensions;
using Ollix.Domain.Aggregates.UserAppAggregate;
using Ollix.Application.UseCases.Orders.Queries.GetOrders;

namespace Ollix.API.Endpoints.Orders
{
    [Authorize]
    public class GetOrders : EndpointBaseAsync
                .WithRequest<GetOrdersRequest>
                .WithActionResult<PaginationResponse<Order>>
    {
        protected readonly IMediator _mediator;

        public GetOrders(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Routes.OrdersUri)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponse<Order>))]
        [SwaggerOperation(
          Summary = "Obter os Pedidos",
          Description = "Retorna os Pedidos realizados, por Cliente (Obrigatório para Admins), status e Data de Solicitação",
          OperationId = "orders.get",
          Tags = new[] { "Pedidos" }
        )]
        public override async Task<ActionResult<PaginationResponse<Order>>> HandleAsync(GetOrdersRequest request,
            CancellationToken cancellationToken = default)
        {
            var userInfo = ApplicationClaims.GetUserInfoByClaims(User.Claims.ToArray());

            var query = new GetOrdersQuery(
                userInfo!,
                request.ClientId,
                request.OrderStatus,
                request.RequestedDate,
                request.PaginationRequest!);

            var result = await _mediator.Send(query, cancellationToken);

            return Ok(result.Value);
        }
    }
}
