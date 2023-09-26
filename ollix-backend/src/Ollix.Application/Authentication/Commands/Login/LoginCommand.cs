using Ollix.Application.Abstractions;
using Ollix.Application.Authentication.Commands.Login;
using Ollix.Domain.UserAggregate;

namespace Ollix.Application.Categories.Commands.CreateCategory;

public sealed record LoginCommand : ICommand<LoginCommandResponse>
{
    public string? Name { get; set; }

    public UserApp ToDomain() 
    { 
        return new UserApp();
    }
}

