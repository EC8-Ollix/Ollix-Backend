﻿using Ardalis.Result;
using MediatR;
using Ollix.Application.UseCases.Orders.Commands.ProcessOrder;
using Ollix.Domain.Aggregates.LogAggregate;
using Ollix.Domain.Aggregates.OrderAggregate;
using Ollix.Domain.Aggregates.PropellerAggregate;
using Ollix.Domain.Events;
using Ollix.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                propeller.RegisterDomainEvent(new EntityControlEvent(request.UserInfo!, EntityEnum.Propeller, OperationEnum.Create, propeller));

                propellers.Add(propeller);
            }

            await _repository.AddRangeAsync(propellers, cancellationToken);

            return Result.Success();
        }
    }
}
