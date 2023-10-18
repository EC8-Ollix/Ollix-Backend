using Ardalis.Result;
using MediatR;
using Ollix.Domain.Aggregates.LogAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate.Models;
using Ollix.Domain.Events;
using Ollix.SharedKernel.Extensions;
using Ollix.SharedKernel.Interfaces;

namespace Ollix.Application.UseCases.Users.Commands.UpdateUser
{
    internal sealed class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Result<UserInfo>>
    {
        private readonly IRepository<UserApp> _repository;
        public UpdateUserCommandHandler(IRepository<UserApp> repository)
        {
            _repository = repository;
        }

        public async Task<Result<UserInfo>> Handle(UpdateUserCommand request,
            CancellationToken cancellationToken)
        {
            if (request.UserId != request.UserInfo!.Id)
                return Result.Error("Você não pode atualizar outro usuário!");

            var user = await _repository.GetByIdAsync(request.UserId, cancellationToken);
            if (user is null)
                return Result.NotFound("Usuário não encontrado!");

            user.SetFirstName(request.FirstName!);
            user.SetLastName(request.LastName!);
            user.SetUserPassword(request.UserPassword!.ToHash());

            user.RegisterDomainEvent(new EntityControlEvent(request.UserInfo, EntityEnum.User, OperationEnum.Update, user));

            await _repository.UpdateAsync(user, cancellationToken);

            return Result.Success(new UserInfo(user));
        }
    }
}
