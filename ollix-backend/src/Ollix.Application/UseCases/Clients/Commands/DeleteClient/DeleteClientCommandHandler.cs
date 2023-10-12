using Ardalis.Result;
using MediatR;
using Ollix.Application.Shared;
using Ollix.Application.UseCases.Users.Queries.GetUsers;
using Ollix.Domain.Aggregates.ClientAppAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate.Specifications;
using Ollix.Domain.Aggregates.UserAppAggregate;
using Ollix.Domain.Models;
using Ollix.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ollix.Application.UseCases.Clients.Queries.GetClientById;

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

        public async Task<Result> Handle(DeleteClientCommand query,
            CancellationToken cancellationToken)
        {
            if(query.ClientId == Guid.Empty)
                return Result.Error("O Cliente deve ser informado para a exclusão!");

            var clientAppResult = await _mediator.Send(new GetClientByIdQuery(query.UserInfo, query.ClientId), cancellationToken);
            if(!clientAppResult.IsSuccess)
                return Result.Error(clientAppResult.Errors.ToArray());

            await _repository.DeleteAsync(clientAppResult.Value, cancellationToken);

            return Result.Success();
        }
    }
}
