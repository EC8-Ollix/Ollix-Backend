using Ollix.Domain.Aggregates.UserAppAggregate.Models;

namespace Ollix.Application.UseCases.Users.Commands.Shared
{
    public record UpsertUserCommand
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public UserInfo? UserInfo { get; set; }
    }
}
