using Ardalis.Result;
using MediatR;
using Ollix.Domain.Aggregates.PropellerAggregate;
using Ollix.SharedKernel.Interfaces;

namespace Ollix.Application.UseCases.Propellers.Queries.GetPropellerById
{
    public sealed class GetPropellerByIdQueryHandler : IRequestHandler<GetPropellerByIdQuery, Result<Propeller>>
    {
        private readonly IRepository<Propeller> _repository;

        public GetPropellerByIdQueryHandler(IRepository<Propeller> repository)
        {
            _repository = repository;
        }

        public async Task<Result<Propeller>> Handle(GetPropellerByIdQuery query,
            CancellationToken cancellationToken)
        {
            var propeller = await _repository.GetByIdAsync(query.PropellerId, cancellationToken);
            if (propeller is null)
                return Result.NotFound("Hélice não encontrada!");

            return Result.Success(propeller);
        }
    }
}
