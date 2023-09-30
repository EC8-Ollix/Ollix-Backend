using Ollix.Application.UseCases.Authentication.Shared;

namespace Ollix.API.Endpoints.Authentication
{
    public record LoginResponse(
        string? Token,
        UserInfo User);
}
