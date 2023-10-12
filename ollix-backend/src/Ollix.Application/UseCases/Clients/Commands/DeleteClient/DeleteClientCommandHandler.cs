using Ardalis.Result;
using MediatR;
using Ollix.Application.UseCases.Clients.Queries.GetClientById;
using Ollix.Domain.Aggregates.ClientAppAggregate;
using Ollix.Domain.Aggregates.LogAggregate;
using Ollix.Domain.Events;
using Ollix.SharedKernel.Interfaces;

namespace Ollix.Application.UseCases.Clients.Commands.DeleteClient
{
    public sealed class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, Result>
    {
        private readonly IRepository<ClientApp> _repository;
        private readonly IMediator _mediator;

        public DeleteClientCommandHandler(IRepository<ClientApp> repository,
            IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<Result> Handle(DeleteClientCommand request,
            CancellationToken cancellationToken)
        {
            if (request.ClientId == Guid.Empty)
                return Result.Error("O Cliente deve ser informado para a exclusão!");

            var clientAppResult = await _mediator.Send(new GetClientByIdQuery(request.UserInfo, request.ClientId), cancellationToken);
            if (!clientAppResult.IsSuccess)
                return Result.Error(clientAppResult.Errors.ToArray());

            var clientApp = clientAppResult.Value;
            clientApp.RegisterDomainEvent(new EntityControlEvent(request.UserInfo, EntityEnum.Client, OperationEnum.Update, clientApp));

            await _repository.DeleteAsync(clientApp, cancellationToken);

            return Result.Success();
        }
    }
}
