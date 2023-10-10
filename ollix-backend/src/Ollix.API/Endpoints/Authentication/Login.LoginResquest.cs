using Ardalis.Result;
using Ollix.API.Shared.Request;
using Ollix.Application.Shared;
using Ollix.Application.UseCases.Authentication.Commands.Login;

namespace Ollix.API.Endpoints.Authentication
{
    public record LoginRequest : IApiRequest<LoginCommand, Result<UserInfo>>
    {
        public string? UserEmail { get; set; }
        public string? UserPassword { get; set; }

        public LoginCommand ToCommand()
        {
            return new LoginCommand()
            {
                UserEmail = UserEmail,
                UserPassword = UserPassword
            };
        }
    }
}
