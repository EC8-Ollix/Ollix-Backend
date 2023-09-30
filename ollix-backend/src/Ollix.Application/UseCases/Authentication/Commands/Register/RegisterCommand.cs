using Ardalis.Result;
using MediatR;
using Ollix.Application.UseCases.Authentication.Shared;
using Ollix.Application.UseCases.Clients.Commands.CreateClient;

namespace Ollix.Application.UseCases.Authentication.Commands.Register
{
    public sealed record RegisterCommand : IRequest<Result<UserInfo>>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPassword { get; set; }
        public CreateClientCommand? CreateClientCommand { get; set; }
    }
}
