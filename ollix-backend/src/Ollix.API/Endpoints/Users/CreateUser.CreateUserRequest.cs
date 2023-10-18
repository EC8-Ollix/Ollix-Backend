using Ardalis.Result;
using Ollix.API.Endpoints.Users.Shared;
using Ollix.API.Shared.Request;
using Ollix.Application.UseCases.Users.Commands.CreateUser;
using Ollix.Domain.Aggregates.UserAppAggregate.Models;

namespace Ollix.API.Endpoints.Users
{
    public record CreateUserRequest : UpsertUserRequest, IApiRequest<CreateUserCommand, Result<UserInfo>>
    {
        public string? UserEmail { get; set; }

        public CreateUserCommand ToCommand()
        {
            return new CreateUserCommand()
            {
                FirstName = FirstName,
                LastName = LastName,
                UserEmail = UserEmail,
                UserPassword = UserPassword,
            };
        }
    }
}
