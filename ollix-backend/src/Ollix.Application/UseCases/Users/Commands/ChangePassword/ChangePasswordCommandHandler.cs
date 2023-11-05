using Ardalis.Result;
using MediatR;
using Ollix.Application.UseCases.Users.Commands.UpdateUser;
using Ollix.Domain.Aggregates.LogAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate.Models;
using Ollix.Domain.Aggregates.UserAppAggregate;
using Ollix.Domain.Events;
using Ollix.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ollix.SharedKernel.Extensions;

namespace Ollix.Application.UseCases.Users.Commands.ChangePassword
{
    internal class ChangePasswordCommandHandler: IRequestHandler<ChangePasswordCommand, Result>
    {
        private readonly IRepository<UserApp> _repository;
        public ChangePasswordCommandHandler(IRepository<UserApp> repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(ChangePasswordCommand request,
            CancellationToken cancellationToken)
        {
            if (request.UserId != request.UserInfo!.Id)
                return Result.Error("Você não pode atualizar outro usuário!");

            var user = await _repository.GetByIdAsync(request.UserId, cancellationToken);
            if (user is null)
                return Result.NotFound("Usuário não encontrado!");

            if(request.CurrentPassword?.ToHash() != user.UserPassword)
                return Result.Error("A senha atual informada está incorreta!");
            
            user.SetUserPassword(request.NewPassword!.ToHash());

            await _repository.UpdateAsync(user, cancellationToken);

            return Result.Success();
        }
    }
}
