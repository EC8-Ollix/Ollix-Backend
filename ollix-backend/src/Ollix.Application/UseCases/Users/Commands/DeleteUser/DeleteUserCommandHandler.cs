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
using Ollix.Application.UseCases.Users.Queries.GetUserById;

namespace Ollix.Application.UseCases.Users.Commands.DeleteUser
{
    public sealed class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Result>
    {
        private readonly IRepository<UserApp> _repository;
        private readonly IMediator _mediator;

        public DeleteUserCommandHandler(IRepository<UserApp> repository,
            IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<Result> Handle(DeleteUserCommand query,
            CancellationToken cancellationToken)
        {
            if(query.UserId == Guid.Empty)
                return Result.Error("O Usuário deve ser informado para a exclusão!");

            var userAppResult = await _mediator.Send(new GetUserByIdQuery(query.UserId), cancellationToken);
            if(!userAppResult.IsSuccess)
                return Result.Error(userAppResult.Errors.ToArray());

            await _repository.DeleteAsync(userAppResult.Value, cancellationToken);

            return Result.Success();
        }
    }
}
