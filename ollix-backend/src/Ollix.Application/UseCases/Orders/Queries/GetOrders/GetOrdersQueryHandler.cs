using Ardalis.Result;
using MediatR;
using Ollix.Application.UseCases.Clients.Queries.GetClientById;
using Ollix.Application.UseCases.Users.Queries.GetUsers;
using Ollix.Domain.Aggregates.UserAppAggregate.Models;
using Ollix.Domain.Aggregates.UserAppAggregate.Specifications;
using Ollix.Domain.Aggregates.UserAppAggregate;
using Ollix.Domain.Models;
using Ollix.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ollix.Domain.Aggregates.OrderAggregate;
using Ollix.Domain.Aggregates.OrderAggregate.Specifications;

namespace Ollix.Application.UseCases.Orders.Queries.GetOrders
{
    public sealed class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, Result<PaginationResponse<Order>>>
    {
        private readonly IRepository<Order> _repository;

        public GetOrdersQueryHandler(IRepository<Order> repository)
        {
            _repository = repository;
        }

        public async Task<Result<PaginationResponse<Order>>> Handle(GetOrdersQuery query,
            CancellationToken cancellationToken)
        {
            var clientId = query.UserInfo.IsClient() ? query.UserInfo.ClientApp!.Id : query.ClientId;

            var countOrders = await _repository
                .CountAsync(new OrdersSpec(clientId, query.OrderStatus, query.RequestedDate), cancellationToken);

            var orders = await _repository
                .ListAsync(new OrdersSpec(query.PaginationRequest, clientId, query.OrderStatus, query.RequestedDate), cancellationToken);

            var ordersResult = new PaginationResponse<Order>
                (orders, countOrders, query.PaginationRequest);

            return Result.Success(ordersResult);
        }
    }
}
