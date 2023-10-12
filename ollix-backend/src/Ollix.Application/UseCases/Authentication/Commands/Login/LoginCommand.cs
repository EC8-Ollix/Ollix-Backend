using Ardalis.Result;
using MediatR;
using Ollix.Domain.Aggregates.UserAppAggregate.Models;

namespace Ollix.Application.UseCases.Authentication.Commands.Login;

public sealed record LoginCommand : IRequest<Result<UserInfo>>
{
    public string? UserEmail { get; set; }
    public string? UserPassword { get; set; }
}

