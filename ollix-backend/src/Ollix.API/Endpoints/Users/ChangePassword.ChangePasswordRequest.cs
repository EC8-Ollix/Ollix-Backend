using Ardalis.Result;
using Microsoft.AspNetCore.Mvc;
using Ollix.API.Endpoints.Users.Shared;
using Ollix.API.Shared.Request;
using Ollix.Application.UseCases.Users.Commands.ChangePassword;
using Ollix.Application.UseCases.Users.Commands.UpdateUser;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Ollix.API.Endpoints.Users
{
    public class ChangePasswordRequest : IApiRequest<ChangePasswordCommand, Result>
    {
        [FromBody]
        public ChangePasswordBodyRequest? ChangePasswordBodyRequest { get; set; }

        [FromRoute(Name = "userId")]
        [FromQuery]
        [Required]
        public Guid UserId { get; set; }

        public ChangePasswordCommand ToCommand()
        {
            return new ChangePasswordCommand()
            { 
                CurrentPassword = ChangePasswordBodyRequest?.CurrentPassword ?? string.Empty,
                NewPassword = ChangePasswordBodyRequest?.NewPassword ?? string.Empty
            };
        }
    }

    public record ChangePasswordBodyRequest
    {
        public string? CurrentPassword { get; set; }
        public string? NewPassword { get; set; }
    }
}
