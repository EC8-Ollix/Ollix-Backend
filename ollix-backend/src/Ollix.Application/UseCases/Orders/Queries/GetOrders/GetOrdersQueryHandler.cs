using Ardalis.Result;
using MediatR;
using Ollix.Domain.Aggregates.OrderAggregate;
using Ollix.Domain.Aggregates.OrderAggregate.Specifications;
using Ollix.Domain.Models;
using Ollix.SharedKernel.Interfaces;

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


            var ordersSpec = new OrdersSpec();
            ordersSpec.WithBaseSpec(clientId,
                              query.RequesterSearch,
                              query.ClientSearch,
                              query.OrderStatus,
                              query.RequestedDate);

            var countOrders = await _repository
                .CountAsync(ordersSpec, cancellationToken);

            ordersSpec.WithPagination(query.PaginationRequest);
            var orders = await _repository
                .ListAsync(ordersSpec, cancellationToken);

            var ordersResult = new PaginationResponse<Order>
                (orders, countOrders, query.PaginationRequest);

            return Result.Success(ordersResult);
        }
    }
}
