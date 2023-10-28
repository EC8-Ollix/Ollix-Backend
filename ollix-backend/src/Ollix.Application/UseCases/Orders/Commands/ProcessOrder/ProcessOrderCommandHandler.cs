using Ardalis.Result;
using MediatR;
using Ollix.Application.UseCases.Propellers.Commands.CreatePropellers;
using Ollix.Domain.Aggregates.LogAggregate;
using Ollix.Domain.Aggregates.OrderAggregate;
using Ollix.Domain.Events;
using Ollix.SharedKernel.Interfaces;

namespace Ollix.Application.UseCases.Orders.Commands.ProcessOrder
{
    public sealed class ProcessOrderCommandHandler : IRequestHandler<ProcessOrderCommand, Result<Order>>
    {
        private readonly IRepository<Order> _repository;
        private readonly IMediator _mediator;

        public ProcessOrderCommandHandler(IRepository<Order> repository,
            IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<Result<Order>> Handle(ProcessOrderCommand request,
            CancellationToken cancellationToken)
        {
            var order = await _repository.GetByIdAsync(request.OrderId, cancellationToken);
            if (order is null)
                return Result.NotFound("Pedido não encontrado!");

            if (order.OrderStatus is not OrderStatus.Pending)
                return Result.Error("O pedido precisa estar Pendente para ser processado!");

            var operation = await ProcessOrder(request, order);
            order.RegisterDomainEvent(new EntityControlEvent(request.UserInfo!, EntityEnum.Order, operation, order));
            await _repository.UpdateAsync(order, cancellationToken);

            return Result.Success(order);
        }

        private async Task<OperationEnum> ProcessOrder(ProcessOrderCommand request, Order order)
        {
            if (request.Approved)
            {
                order.ScheduleInstallation(request.InstallationDate);
                await _mediator.Send(new CreatePropellersCommand(order, request.UserInfo!));

                return OperationEnum.OrderApproved;
            }

            order.SetOrderStatus(OrderStatus.Denied);
            return OperationEnum.OrderDenied;
        }
    }
}
