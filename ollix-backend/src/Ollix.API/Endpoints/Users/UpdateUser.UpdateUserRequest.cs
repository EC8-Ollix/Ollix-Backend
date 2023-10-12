using Ardalis.Result;
using Microsoft.AspNetCore.Mvc;
using Ollix.API.Endpoints.Users.Shared;
using Ollix.API.Shared.Request;
using Ollix.Application.Shared;
using Ollix.Application.UseCases.Users.Commands.CreateUser;
using Ollix.Application.UseCases.Users.Commands.UpdateUser;
using System.ComponentModel.DataAnnotations;

namespace Ollix.API.Endpoints.Users
{
    public class UpdateUserRequest : IApiRequest<UpdateUserCommand, Result<UserInfo>>
    {
        [FromBody]
        public UpsertUserRequest? UpsertUserRequest { get; set; }

        [FromRoute(Name = "userId")]
        [FromQuery]
        [Required]
        public Guid UserId { get; set; }

        public UpdateUserCommand ToCommand()
        {
            return new UpdateUserCommand()
            {
                FirstName = UpsertUserRequest?.FirstName,
                LastName = UpsertUserRequest?.LastName,
                UserPassword = UpsertUserRequest?.UserPassword,
            };

        }
    }
}
