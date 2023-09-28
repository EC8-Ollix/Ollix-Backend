using Ollix.Application.UseCases.Authentication.Shared;

namespace Ollix.API.Endpoints.Authentication
{
    public record RegisterResponse(       
        UserInfo User);
}
