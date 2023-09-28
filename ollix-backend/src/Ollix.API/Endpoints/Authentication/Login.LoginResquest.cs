using Ollix.API.Shared.Request;
using Ollix.Application.UseCases.Authentication.Commands.Login;
using Ollix.Application.UseCases.Authentication.Shared;
using Ollix.Domain.UserAggregate;
using System.ComponentModel.DataAnnotations;

namespace Ollix.API.Endpoints.Authentication
{
    public record LoginRequest : IApiRequest<LoginCommand, UserInfo>
    {
        [Required(ErrorMessage = "O Email é obrigatório")]
        [MaxLength(200, ErrorMessage = "O Email deve ter no máximo 100 caracteres")]
        public string? UserEmail { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [MaxLength(60, ErrorMessage = "A senha deve ter no 60 caracteres")]
        public string? UserPassword { get; set; }

        public LoginCommand ToCommand()
        {
            return new LoginCommand() 
            {
                UserEmail = UserEmail,
                UserPassword = UserPassword
            };
        }
    }
}
