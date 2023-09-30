﻿using Ardalis.Result;
using MediatR;
using Ollix.Application.UseCases.Authentication.Shared;
using Ollix.Domain.UserAggregate;
using Ollix.Domain.UserAppAggregate.Specifications;
using Ollix.SharedKernel.Extensions;
using Ollix.SharedKernel.Interfaces;

namespace Ollix.Application.UseCases.Authentication.Commands.Login;

internal sealed class LoginCommandHandler : IRequestHandler<LoginCommand, Result<UserInfo>>
{
    private readonly IRepository<UserApp> _repository;
    private readonly Result credencialsError = Result.Error("As credenciais informadas estão inválidas!");

    public LoginCommandHandler(IRepository<UserApp> repository)
    {
        _repository = repository;
    }

    public async Task<Result<UserInfo>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository
            .FirstOrDefaultAsync(new GetUserAppByEmailSpec(request.UserEmail!), cancellationToken);

        if (user is null)
            return credencialsError;

        if (user.UserPassword!.Equals(request.UserPassword!.ToHash()))
            return Result.Success(new UserInfo(user));

        return credencialsError;
    }
}
