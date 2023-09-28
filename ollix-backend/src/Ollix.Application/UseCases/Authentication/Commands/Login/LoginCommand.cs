using Ollix.Application.Abstractions;
using Ollix.Application.UseCases.Authentication.Shared;
using Ollix.Domain.UserAggregate;

namespace Ollix.Application.UseCases.Authentication.Commands.Login;

public sealed record LoginCommand : ICommand<UserInfo>
{
    public string? UserEmail { get; set; }
    public string? UserPassword { get; set; }
}

