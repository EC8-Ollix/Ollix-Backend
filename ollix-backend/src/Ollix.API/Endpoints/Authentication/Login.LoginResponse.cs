using Ollix.Application.Authentication.Commands.Login;

namespace Ollix.API.Endpoints.Authentication
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public LoginResponse(LoginCommandResponse response)
        {
            Token = "ASDDSASDASASDA155";
        }
    }
}
