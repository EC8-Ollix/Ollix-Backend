using Ardalis.Result;
using MediatR;
using Ollix.Application.UseCases.Users.Queries.GetUserById;
using Ollix.Domain.Aggregates.LogAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate;
using Ollix.Domain.Events;
using Ollix.SharedKernel.Interfaces;

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

        public async Task<Result> Handle(DeleteUserCommand request,
            CancellationToken cancellationToken)
        {
            if (request.UserId == Guid.Empty)
                return Result.Error("O Usuário deve ser informado para a exclusão!");

            var userAppResult = await _mediator.Send(new GetUserByIdQuery(request.UserId), cancellationToken);
            if (!userAppResult.IsSuccess)
                return Result.Error(userAppResult.Errors.ToArray());

            var userApp = userAppResult.Value;
            userApp.RegisterDomainEvent(new EntityControlEvent(request.UserInfo, 
                EntityEnum.User, OperationEnum.Delete, userApp, userApp.UserEmail!));

            await _repository.DeleteAsync(userApp, cancellationToken);

            return Result.Success();
        }
    }
}
