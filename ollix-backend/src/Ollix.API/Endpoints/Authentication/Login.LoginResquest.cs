using Ardalis.Result;
using Ollix.API.Shared.Request;
using Ollix.Application.UseCases.Authentication.Commands.Login;
using Ollix.Application.UseCases.Authentication.Shared;

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
