using Ardalis.Result;
using MediatR;
using Ollix.Domain.Aggregates.LogAggregate;
using Ollix.Domain.Aggregates.OrderAggregate;
using Ollix.Domain.Events;
using Ollix.SharedKernel.Extensions;
using Ollix.SharedKernel.Interfaces;

namespace Ollix.Application.UseCases.Orders.Commands.CancelOrder
{
    public sealed class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand, Result>
    {
        private readonly IRepository<Order> _repository;

        public CancelOrderCommandHandler(IRepository<Order> repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(CancelOrderCommand request,
            CancellationToken cancellationToken)
        {
            if (request.OrderId == Guid.Empty)
                return Result.Error("O Pedido deve ser informado para o cancelamento!");

            var order = await _repository.GetByIdAsync(request.OrderId, cancellationToken);
            if (order is null)
                return Result.NotFound("Pedido não encontrado!");

            if (order.OrderStatus is OrderStatus.Cancel)
                return Result.Success();

            if (!order.CanCancel())
                return Result.Error($"Não é possivel cancelar um pedido com status '{order.OrderStatus.GetDescription()}'");

            order.SetOrderStatus(OrderStatus.Cancel);
            order.RegisterDomainEvent(new EntityControlEvent(request.UserInfo, EntityEnum.Order, OperationEnum.CancelOrder, order));

            await _repository.UpdateAsync(order, cancellationToken);

            return Result.Success();
        }
    }
}
