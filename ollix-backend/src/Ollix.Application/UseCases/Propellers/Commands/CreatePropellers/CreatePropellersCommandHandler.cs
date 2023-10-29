using Ardalis.Result;
using MediatR;
using Ollix.Domain.Aggregates.LogAggregate;
using Ollix.Domain.Aggregates.PropellerAggregate;
using Ollix.Domain.Events;
using Ollix.SharedKernel.Interfaces;

namespace Ollix.Application.UseCases.Propellers.Commands.CreatePropellers
{
    public sealed class CreatePropellersCommandHandler : IRequestHandler<CreatePropellersCommand, Result>
    {
        private readonly IRepository<Propeller> _repository;

        public CreatePropellersCommandHandler(IRepository<Propeller> repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(CreatePropellersCommand request, CancellationToken cancellationToken)
        {
            var propellers = new List<Propeller>();
            for (int i = 0; i < request.Order.QuantityRequested; i++)
            {
                var propeller = new Propeller(request.Order);

                propeller.RegisterDomainEvent(new EntityControlEvent(request.UserInfo!, 
                    EntityEnum.Propeller, OperationEnum.Create, propeller, propeller.HelixId!));

                propellers.Add(propeller);
            }

            await _repository.AddRangeAsync(propellers, cancellationToken);

            return Result.Success();
        }
    }
}
