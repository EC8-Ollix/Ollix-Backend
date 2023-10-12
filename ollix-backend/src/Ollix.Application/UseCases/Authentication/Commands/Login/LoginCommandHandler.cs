using Ardalis.Result;
using MediatR;
using Ollix.Application.Shared;
using Ollix.Application.UseCases.Clients.Queries.GetClientById;
using Ollix.Domain.Aggregates.UserAppAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate.Specifications;
using Ollix.SharedKernel.Extensions;
using Ollix.SharedKernel.Interfaces;

namespace Ollix.Application.UseCases.Authentication.Commands.Login;

internal sealed class LoginCommandHandler : IRequestHandler<LoginCommand, Result<UserInfo>>
{
    private readonly IRepository<UserApp> _repository;
    private readonly IMediator _mediator;
    private readonly Result credencialsError = Result.Error("As credenciais informadas estão inválidas!");

    public LoginCommandHandler(IRepository<UserApp> repository,
        IMediator mediator)
    {
        _repository = repository;
        _mediator = mediator;
    }

    public async Task<Result<UserInfo>> Handle(LoginCommand request, 
        CancellationToken cancellationToken)
    {
        var user = await _repository
            .FirstOrDefaultAsync(new UserAppByEmailSpec(request.UserEmail!.ToLower()!), cancellationToken);

        if (user is null)
            return credencialsError;

        if (user.UserPassword!.Equals(request.UserPassword!.ToHash()))
        {
            var userInfo = new UserInfo(user);
            var clientApp = await _mediator.Send(new GetClientByIdQuery(userInfo, user.ClientId), cancellationToken);

            userInfo.ClientApp = clientApp;

            return Result.Success(userInfo);
        }


        return credencialsError;
    }
}

