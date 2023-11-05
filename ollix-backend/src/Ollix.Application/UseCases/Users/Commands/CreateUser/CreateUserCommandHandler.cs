using Ardalis.Result;
using MediatR;
using Ollix.Domain.Aggregates.LogAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate.Models;
using Ollix.Domain.Aggregates.UserAppAggregate.Specifications;
using Ollix.Domain.Events;
using Ollix.SharedKernel.Extensions;
using Ollix.SharedKernel.Interfaces;

namespace Ollix.Application.UseCases.Users.Commands.CreateUser
{
    internal sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<UserInfo>>
    {
        private readonly IRepository<UserApp> _repository;
        public CreateUserCommandHandler(IRepository<UserApp> repository)
        {
            _repository = repository;
        }

        public async Task<Result<UserInfo>> Handle(CreateUserCommand request,
            CancellationToken cancellationToken)
        {
            var user = await _repository
                .FirstOrDefaultAsync(new UserAppByEmailSpec(request.UserEmail!), cancellationToken);

            if (user is not null)
                return Result.Error("Email já cadastrado na plataforma");

            user = new UserApp(
                request.FirstName!,
                request.LastName!,
                request.UserInfo!.UserType,
                request.UserEmail!.ToLower()!,
                request.UserPassword!.ToHash(),
                request.UserInfo.ClientApp!.Id);

            user.RegisterDomainEvent(new EntityControlEvent(request.UserInfo, 
                EntityEnum.User, OperationEnum.Create, user, user.UserEmail!));

            await _repository.AddAsync(user, cancellationToken);

            return Result.Success(new UserInfo(user));
        }
    }
}
