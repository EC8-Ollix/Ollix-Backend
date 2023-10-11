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

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.UserPassword = request.UserPassword!.ToHash();      

            await _repository.UpdateAsync(user, cancellationToken);

            return Result.Success(new UserInfo(user));
        }
    }
}
