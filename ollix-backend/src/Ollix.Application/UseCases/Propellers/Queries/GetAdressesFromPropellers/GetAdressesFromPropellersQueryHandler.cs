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
using Ollix.Domain.Aggregates.AddressAppAggregate.Models;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Ollix.Application.UseCases.Propellers.Queries.GetAdressesFromPropellers
{
    public sealed class GetAdressesFromPropellersQueryHandler : IRequestHandler<GetAdressesFromPropellersQuery, Result<PaginationResponse<AddressPropellerModel>>>
    {
        private readonly IRepository<Propeller> _repository;

        public GetAdressesFromPropellersQueryHandler(IRepository<Propeller> repository)
        {
            _repository = repository;
        }

        public async Task<Result<PaginationResponse<AddressPropellerModel>>> Handle(GetAdressesFromPropellersQuery query,
            CancellationToken cancellationToken)
        {
            var clientId = query.UserInfo.IsClient() ? query.UserInfo.ClientApp!.Id : query.ClientId;

            var adresses = await _repository
                .ListAsync(new PropellersSpecByAddress(clientId, query.State, query.City, query.UserInfo.IsClient() ? true : null), cancellationToken);

            var uniqueAdresses = adresses.DistinctBy(a => a!.Id);

            var adressesGrouped = uniqueAdresses
                .Skip(query.PaginationRequest.Page - 1)
                .Take(query.PaginationRequest.PageSize)
                .Select(a => new AddressPropellerModel(a, adresses.Where(b => b.Id == a.Id).Count()))
                .ToArray();

            var adressesResult = new PaginationResponse<AddressPropellerModel>
                (adressesGrouped, uniqueAdresses.Count(), query.PaginationRequest);

            return Result.Success(adressesResult);
        }
    }
}
