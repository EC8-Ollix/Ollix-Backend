using Ardalis.Result;
using MediatR;
using Ollix.Application.UseCases.Orders.Queries.GetOrders;
using Ollix.Domain.Aggregates.OrderAggregate.Specifications;
using Ollix.Domain.Aggregates.OrderAggregate;
using Ollix.Domain.Models;
using Ollix.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ollix.Domain.Aggregates.PropellerAggregate;
using Ollix.Domain.Aggregates.PropellerAggregate.Models;
using Ollix.Domain.Aggregates.PropellerAggregate.Specifications;
using Ollix.Infrastructure.Data.DataBaseContext;

namespace Ollix.Application.UseCases.Propellers.Queries.GetPropellersByAddress
{
    public sealed class GetPropellersByAddressQueryHandler : IRequestHandler<GetPropellersByAddressQuery, Result<PaginationResponse<Propeller>>>
    {
        private readonly IRepository<Propeller> _repository;

        public GetPropellersByAddressQueryHandler(IRepository<Propeller> repository)
        {
            _repository = repository;
        }

        public async Task<Result<PaginationResponse<Propeller>>> Handle(GetPropellersByAddressQuery query,
            CancellationToken cancellationToken)
        {
            Guid clientId = query.ClientId;
            bool? installed = query.Installed;

            if (query.UserInfo.IsClient())
            {
                clientId = query.UserInfo.ClientApp!.Id;
                installed = true;
            }

            var spec = new PropellersSpec(query.PaginationRequest, clientId, query.OrderId, query.AddressId, query.Active, installed);
            var propellers = await _repository.ListAsync(spec, cancellationToken);
            var propellersCount = await _repository.CountAsync(new PropellersSpec(clientId, query.OrderId, query.AddressId, query.Active, installed), cancellationToken);

            var propellersResult = new PaginationResponse<Propeller>
                (propellers, propellersCount, query.PaginationRequest);

            return Result.Success(propellersResult);
        }
    }

}
