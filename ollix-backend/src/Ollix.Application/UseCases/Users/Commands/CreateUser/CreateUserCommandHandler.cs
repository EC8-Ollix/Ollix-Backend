using Ardalis.Result;
using MediatR;
using Ollix.Application.Shared;
using Ollix.Application.UseCases.Authentication.Commands.Register;
using Ollix.Domain.Aggregates.UserAppAggregate.Specifications;
using Ollix.Domain.Aggregates.UserAppAggregate;
using Ollix.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ollix.SharedKernel.Extensions;

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
                .FirstOrDefaultAsync(new GetUserAppByEmailSpec(request.UserEmail!), cancellationToken);

            if (user is not null)
                return Result.Error("Email já cadastrado na plataforma");
            
            user = new UserApp()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserEmail = request.UserEmail!.ToLower()!,
                UserPassword = request.UserPassword!.ToHash(),
                UserType = request.UserInfo!.UserType,
                ClientId = request.UserInfo.ClientApp!.Id,
            };

            await _repository.AddAsync(user, cancellationToken);

            return Result.Success(new UserInfo(user));
        }
    }
}
