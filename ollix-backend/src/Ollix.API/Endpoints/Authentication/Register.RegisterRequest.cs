using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Ollix.API.Shared.Request;
using Ollix.Application.Authentication.Commands.Register;
using Ollix.Application.UseCases.Authentication.Commands.Register;
using Ollix.Application.UseCases.Authentication.Shared;
using System.ComponentModel.DataAnnotations;

namespace Ollix.API.Endpoints.Authentication
{
    public class RegisterRequest : IApiRequest<RegisterCommand, UserInfo>
    {
        [Required(ErrorMessage = "O Nome é obrigatório")]
        [MaxLength(100, ErrorMessage = "O Nome deve ter no máximo 100 caracteres")]
        public string? FirstName { get; set; }

        [MaxLength(200, ErrorMessage = "O Nome deve ter no máximo 100 caracteres")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "O Email é obrigatório")]
        [MaxLength(200, ErrorMessage = "O Email deve ter no máximo 200 caracteres")]
        public string? UserEmail { get; set; }

        [Required(ErrorMessage = "A Senha é obrigatória")]
        [MaxLength(200, ErrorMessage = "A Senha deve ter no máximo 60 caracteres")]
        public string? UserPassword { get; set; }


        [Required(ErrorMessage = "O Nome da Empresa é obrigatório")]
        [MaxLength(200, ErrorMessage = "O Nome da Empresa deve ter no máximo 400 caracteres")]
        public string? CompanyName { get; set; }

        [Required(ErrorMessage = "O Nome Fantasia da Empresa é obrigatório")]
        [MaxLength(200, ErrorMessage = "O Nome Fantasia da Empresa deve ter no máximo 400 caracteres")]
        public string? BussinessName { get; set; }

        [Required(ErrorMessage = "O CNPJ é obrigatório")]
        [MaxLength(14, ErrorMessage = "O CNPJ deve ter 14 caracteres")]
        [MinLength(14, ErrorMessage = "O CNPJ deve ter 14 caracteres")]
        public string? Cnpj { get; set; }

        public RegisterCommand ToCommand()
        {
            return new RegisterCommand()
            {
                FirstName = FirstName,
                LastName = LastName,
                UserEmail = UserEmail,
                UserPassword = UserPassword,
                CreateClientCommand = new CreateClientCommand()
                {
                    CompanyName = CompanyName,
                    BussinessName = BussinessName,
                    Cnpj = Cnpj
                }
            };
        }
    }
}
