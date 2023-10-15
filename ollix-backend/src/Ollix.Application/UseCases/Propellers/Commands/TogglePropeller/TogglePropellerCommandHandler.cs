using Ardalis.Result;
using MediatR;
using Ollix.Domain.Aggregates.LogAggregate;
using Ollix.Domain.Aggregates.PropellerAggregate;
using Ollix.Domain.Events;
using Ollix.SharedKernel.Interfaces;

namespace Ollix.Application.UseCases.Propellers.Commands.TogglePropeller
{
    public sealed class TogglePropellerCommandHandler : IRequestHandler<TogglePropellerCommand, Result>
    {
        private readonly IRepository<Propeller> _repository;

        public TogglePropellerCommandHandler(IRepository<Propeller> repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(TogglePropellerCommand request,
            CancellationToken cancellationToken)
        {
            var propeller = await _repository.GetByIdAsync(request.PropellerId, cancellationToken);
            if (propeller is null)
                return Result.NotFound("Hélice não encontrada!");

            propeller.ToggleActive();

            var operation = propeller.Active ? OperationEnum.ActivePropeller : OperationEnum.InactivePropeller;
            propeller.RegisterDomainEvent(new EntityControlEvent(request.UserInfo, EntityEnum.Client, operation, propeller));

            await _repository.UpdateAsync(propeller, cancellationToken);

            return Result.Success();
        }
    }
}
