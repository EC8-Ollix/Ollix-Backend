using Ardalis.Result;
using Ollix.API.Shared.Request;
using Ollix.Application.UseCases.Authentication.Commands.Register;
using Ollix.Application.UseCases.Clients.Commands.CreateClient;
using Ollix.Domain.Aggregates.UserAppAggregate.Models;
using Ollix.SharedKernel.Extensions;

namespace Ollix.API.Endpoints.Authentication
{
    public class RegisterRequest : IApiRequest<RegisterCommand, Result<UserInfo>>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPassword { get; set; }
        public string? CompanyName { get; set; }
        public string? BussinessName { get; set; }
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
                    Cnpj = Cnpj.JustNumbers()
                }
            };
        }
    }
}
