using Ardalis.Result;
using MediatR;
using Ollix.Application.UseCases.Clients.Commands.DeleteClient;
using Ollix.Application.UseCases.Clients.Queries.GetClientById;
using Ollix.Domain.Aggregates.ClientAppAggregate;
using Ollix.Domain.Aggregates.LogAggregate;
using Ollix.Domain.Events;
using Ollix.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Application.UseCases.Clients.Commands.ToggleClient
{
    public sealed class ToggleClientCommandHandler : IRequestHandler<ToggleClientCommand, Result>
    {
        private readonly IRepository<ClientApp> _repository;

        public ToggleClientCommandHandler(IRepository<ClientApp> repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(ToggleClientCommand request,
            CancellationToken cancellationToken)
        {
            if (request.ClientId == Guid.Empty)
                return Result.Error("O Cliente deve ser informado para a desativação!");

            var clientApp = await _repository.GetByIdAsync(request.ClientId, cancellationToken);
            if (clientApp is null)
                return Result.NotFound("Cliente não encontrado!");

            if (clientApp.Id == request.UserInfo!.ClientApp!.Id && request.UserInfo.IsAdmin())
                return Result.Error("Não é permitido desativar seu proprio cliente!");

            clientApp.ToggleActive();

            var operation = clientApp.Active ? OperationEnum.ActiveClient : OperationEnum.InactiveClient;
            clientApp.RegisterDomainEvent(new EntityControlEvent(request.UserInfo, EntityEnum.Client, operation, clientApp));

            await _repository.UpdateAsync(clientApp, cancellationToken);

            return Result.Success();
        }
    }
}
