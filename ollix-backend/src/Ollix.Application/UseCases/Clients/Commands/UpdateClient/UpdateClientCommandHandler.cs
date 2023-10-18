using Ardalis.Result;
using MediatR;
using Ollix.Domain.Aggregates.ClientAppAggregate;
using Ollix.Domain.Aggregates.LogAggregate;
using Ollix.Domain.Events;
using Ollix.SharedKernel.Interfaces;

namespace Ollix.Application.UseCases.Clients.Commands.CreateClient
{
    internal sealed class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, Result<ClientApp>>
    {
        private readonly IRepository<ClientApp> _repository;

        public UpdateClientCommandHandler(IRepository<ClientApp> repository)
        {
            _repository = repository;
        }

        public async Task<Result<ClientApp>> Handle(UpdateClientCommand request,
            CancellationToken cancellationToken)
        {
            var client = await _repository.GetByIdAsync(request.ClientId, cancellationToken);
            if (client is null)
                return Result.NotFound("Cliente não encontrado!");

            if (request.UserInfo!.ClientApp!.Id != client.Id)
                return Result.NotFound("Usuário não autorizado a editar o Cliente!");

            client.SetCompanyName(request.CompanyName);
            client.SetBussinessName(request.BussinessName);

            client.RegisterDomainEvent(new EntityControlEvent(request.UserInfo, EntityEnum.Client, OperationEnum.Update, client));

            await _repository.UpdateAsync(client, cancellationToken);

            return Result.Success(client);
        }
    }
}
