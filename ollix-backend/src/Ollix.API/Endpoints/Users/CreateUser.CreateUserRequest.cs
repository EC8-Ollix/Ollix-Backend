using Ardalis.Result;
using Ollix.API.Endpoints.Users.Shared;
using Ollix.API.Shared.Request;
using Ollix.Application.Shared;
using Ollix.Application.UseCases.Authentication.Commands.Register;
using Ollix.Application.UseCases.Clients.Commands.CreateClient;
using Ollix.Application.UseCases.Users.Commands.CreateUser;
using Ollix.SharedKernel.Extensions;

namespace Ollix.API.Endpoints.Users
{
    public class CreateUserRequest : UpsertUserRequest, IApiRequest<CreateUserCommand, Result<UserInfo>>
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
