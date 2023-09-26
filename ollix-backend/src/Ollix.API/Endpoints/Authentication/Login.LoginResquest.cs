using Ollix.API.Shared.Request;
using Ollix.Application.Authentication.Commands.Login;
using Ollix.Application.Categories.Commands.CreateCategory;
using System.ComponentModel.DataAnnotations;

namespace Ollix.API.Endpoints.Authentication
{
    public class LoginRequest : IApiRequest<LoginCommand, LoginCommandResponse>
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [MaxLength(100, ErrorMessage = "São permitidos no máximo 100 caracteres")]
        public string Name { get; set; }

        public LoginCommand ToCommand()
        {
            return new LoginCommand() 
            { 
                Name = Name 
            };
        }
    }
}
