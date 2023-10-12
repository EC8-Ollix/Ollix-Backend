using Ollix.Domain.Aggregates.UserAppAggregate.Models;

namespace Ollix.API.Endpoints.Authentication
{
    public record LoginResponse(
        string? Token,
        UserInfo User);
}
