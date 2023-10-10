using Ollix.Application.Shared;

namespace Ollix.API.Endpoints.Authentication
{
    public record LoginResponse(
        string? Token,
        UserInfo User);
}
