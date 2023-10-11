using Ardalis.Result;
using MediatR;
using Ollix.Application.Shared;
using Ollix.Domain.Aggregates.UserAppAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate.Specifications;
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

    public async Task<Result<UserInfo>> Handle(LoginCommand request, 
        CancellationToken cancellationToken)
    {
        var user = await _repository
            .FirstOrDefaultAsync(new GetUserAppByEmailSpec(request.UserEmail!.ToLower()!), cancellationToken);

        if (user is null)
            return credencialsError;

        if (user.UserPassword!.Equals(request.UserPassword!.ToHash()))
            return Result.Success(new UserInfo(user));

        return credencialsError;
    }
}

