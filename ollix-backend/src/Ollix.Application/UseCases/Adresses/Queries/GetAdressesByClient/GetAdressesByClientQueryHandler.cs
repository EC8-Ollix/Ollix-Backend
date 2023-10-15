using Ardalis.Result;
using MediatR;
using Ollix.Application.UseCases.Propellers.Queries.GetAdressesFromPropellers;
using Ollix.Domain.Aggregates.AddressAppAggregate.Models;
using Ollix.Domain.Aggregates.PropellerAggregate.Specifications;
using Ollix.Domain.Aggregates.PropellerAggregate;
using Ollix.Domain.Models;
using Ollix.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ollix.Domain.Aggregates.AddressAppAggregate;

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
                .ListAsync(new PropellersSpecByAddress(clientId, null, null, query.UserInfo.IsClient() ? true : null), cancellationToken);

            return Result.Success(adresses.DistinctBy(a => a.Id!).ToArray());
        }
    }
}
