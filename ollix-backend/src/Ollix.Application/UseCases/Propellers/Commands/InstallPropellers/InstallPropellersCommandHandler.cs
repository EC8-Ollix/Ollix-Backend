using Ardalis.Result;
using MediatR;
using Ollix.Domain.Aggregates.LogAggregate;
using Ollix.Domain.Aggregates.PropellerAggregate;
using Ollix.Domain.Aggregates.PropellerAggregate.Specifications;
using Ollix.Domain.Events;
using Ollix.SharedKernel.Interfaces;

namespace Ollix.Application.UseCases.Propellers.Commands.InstallPropellers
{
    public sealed class InstallPropellersCommandHandler : IRequestHandler<InstallPropellersCommand, Result>
    {
        private readonly IRepository<Propeller> _repository;

        public InstallPropellersCommandHandler(IRepository<Propeller> repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(InstallPropellersCommand request,
            CancellationToken cancellationToken)
        {
            var propellers = await _repository.ListAsync(new PropellersByOrderSpec(request.Order!), cancellationToken);
            foreach (var propeller in propellers)
            {
                propeller.Active = true;
                propeller.Installed = true;

                propeller.RegisterDomainEvent(new EntityControlEvent(request.UserInfo!, 
                    EntityEnum.Propeller, OperationEnum.PropellerInstalled, propeller, propeller.HelixId!));
            }

            await _repository.UpdateRangeAsync(propellers, cancellationToken);

            return Result.Success();
        }
    }
}
