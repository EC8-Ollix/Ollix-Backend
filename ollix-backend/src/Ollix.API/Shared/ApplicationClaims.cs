using Ollix.Domain.Aggregates.ClientAppAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate;
using Ollix.Domain.Aggregates.UserAppAggregate.Models;
using Ollix.SharedKernel.Extensions;
using System.Security.Claims;

namespace Ollix.API.Shared
{
    public static class ApplicationClaims
    {
        public const string UserId = "userId";
        public const string FirstName = "firstName";
        public const string LastName = "lastName";
        public const string Email = "userEmail";
        public const string UserType = "userType";
        public const string ClientId = "clientId";

        public static UserInfo? GetUserInfoByClaims(IEnumerable<Claim> claims)
        {
            if (!claims.Any())
                return null;

            return new UserInfo
            {
                Id = Guid.Parse(claims.FirstOrDefault(p => p.Type == UserId)!.Value),
                FirstName = claims.FirstOrDefault(p => p.Type == FirstName)!.Value,
                LastName = claims.FirstOrDefault(p => p.Type == LastName)!.Value,
                UserEmail = claims.FirstOrDefault(p => p.Type == Email)!.Value,
                UserType = (claims.FirstOrDefault(p => p.Type == UserType)!.Value).GetEnum<UserType>(),
                ClientApp = new ClientApp()
                {
                    Id = Guid.Parse(claims.FirstOrDefault(p => p.Type == ClientId)!.Value)
                }
            };
        }
    }
}
