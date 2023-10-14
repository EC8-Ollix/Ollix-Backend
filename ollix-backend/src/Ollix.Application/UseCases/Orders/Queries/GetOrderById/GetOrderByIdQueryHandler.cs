using Ardalis.Result;
using MediatR;
using Ollix.Domain.Aggregates.OrderAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate;
using Ollix.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Application.UseCases.Orders.Queries.GetOrderById
{
    public sealed class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Result<Order>>
    {
        private readonly IRepository<Order> _repository;

        public GetOrderByIdQueryHandler(IRepository<Order> repository)
        {
            _repository = repository;
        }

        public async Task<Result<Order>> Handle(GetOrderByIdQuery query,
            CancellationToken cancellationToken)
        {
            var order = await _repository.GetByIdAsync(query.OrderId, cancellationToken);
            if (order is null)
                return Result.NotFound("Pedido não encontrado!");

            return Result.Success(order);
        }
    }
}
