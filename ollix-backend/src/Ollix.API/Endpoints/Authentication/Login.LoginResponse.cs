using Ollix.API.Endpoints.Authentication.Shared;
using Ollix.Application.UseCases.Authentication.Shared;
using Ollix.Domain.UserAggregate;

namespace Ollix.API.Endpoints.Authentication
{
    public record LoginResponse(
        string? Token,
        UserInfo User);
}
