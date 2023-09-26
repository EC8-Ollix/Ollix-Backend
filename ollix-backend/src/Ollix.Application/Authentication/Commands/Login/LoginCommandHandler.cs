using Ardalis.Result;
using Ardalis.Specification;
using Ollix.Application.Abstractions;
using MediatR;
using Ollix.Domain.UserAggregate;
using Ollix.SharedKernel.Interfaces;
using Ollix.Domain.Shared.Specifications;
using Ollix.Application.Authentication.Commands.Login;

namespace Ollix.Application.Categories.Commands.CreateCategory;

internal sealed class LoginCommandHandler : ICommandHandler<LoginCommand, LoginCommandResponse>
{
    //private readonly IRepository<UserApp> _repository;

    public LoginCommandHandler(/*IRepository<UserApp> repository*/)
    {
        //_repository = repository;
    }

    public async Task<Result<LoginCommandResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = request.ToDomain();
        var response = new LoginCommandResponse();

        return Result.Success(response);
    }
}

