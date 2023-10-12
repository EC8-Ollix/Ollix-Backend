using Ardalis.Result;
using Microsoft.AspNetCore.Mvc;
using Ollix.API.Endpoints.Users.Shared;
using Ollix.API.Shared.Request;
using Ollix.Application.UseCases.Users.Commands.UpdateUser;
using Ollix.Domain.Aggregates.UserAppAggregate.Models;
using System.ComponentModel.DataAnnotations;

namespace Ollix.API.Endpoints.Users
{
    public record UpdateUserRequest : IApiRequest<UpdateUserCommand, Result<UserInfo>>
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
