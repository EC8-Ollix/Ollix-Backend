using Ardalis.Result;
using MediatR;
using Ollix.Application.UseCases.Propellers.Commands.InstallPropellers;
using Ollix.Domain.Aggregates.LogAggregate;
using Ollix.Domain.Aggregates.OrderAggregate;
using Ollix.Domain.Events;
using Ollix.SharedKernel.Extensions;
using Ollix.SharedKernel.Interfaces;

namespace Ollix.Application.UseCases.Orders.Commands.ConfirmIntallation
{
    public sealed class ConfirmInstallationCommandHandler : IRequestHandler<ConfirmInstallationCommand, Result<Order>>
    {
        private readonly IRepository<Order> _repository;
        private readonly IMediator _mediator;

        public ConfirmInstallationCommandHandler(IRepository<Order> repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<Result<Order>> Handle(ConfirmInstallationCommand request, CancellationToken cancellationToken)
        {
            if (request.OrderId == Guid.Empty)
                return Result.Error("O Pedido deve ser informado para o confirmar instalação!");

            var order = await _repository.GetByIdAsync(request.OrderId, cancellationToken);
            if (order is null)
                return Result.NotFound("Pedido não encontrado!");

            if (!order.CanConfirmInstallation())
                return Result.Error($"O Pedido deve ter o status '{OrderStatus.InstallationPending.GetDescription()}' " +
                    $"para ter sua instalação confirmada!");

            order.SetOrderStatus(OrderStatus.Completed);
            await _mediator.Send(new InstallPropellersCommand(order, request.UserInfo!), cancellationToken);

            order.RegisterDomainEvent(new EntityControlEvent(request.UserInfo!, 
                EntityEnum.Order, OperationEnum.OrderCompleted, order, order.OrderNumber!));

            await _repository.UpdateAsync(order, cancellationToken);

            return Result.Success(order);
        }

    }
}
