using Ardalis.Result;
using MediatR;
using Ollix.Domain.Aggregates.AddressAppAggregate;
using Ollix.Domain.Aggregates.PropellerAggregate;
using Ollix.Domain.Aggregates.PropellerAggregate.Specifications;
using Ollix.SharedKernel.Interfaces;

namespace Ollix.Application.UseCases.Adresses.Queries.GetAdressesByClient
{
    public sealed class GetAdressesByClientQueryHandler : IRequestHandler<GetAdressesByClientQuery, Result<AddressApp[]>>
    {
        private readonly IRepository<Propeller> _repository;

        public GetAdressesByClientQueryHandler(IRepository<Propeller> repository)
        {
            _repository = repository;
        }

        public async Task<Result<AddressApp[]>> Handle(GetAdressesByClientQuery query,
            CancellationToken cancellationToken)
        {
            var clientId = query.UserInfo.IsClient() ? query.UserInfo.ClientApp!.Id : query.ClientId;

            var adresses = await _repository
                .ListAsync(new PropellersSpecByAddress(clientId, null, null, null, null, null), cancellationToken);

            return Result.Success(adresses.DistinctBy(a => a.Id!).ToArray());
        }
    }
}
