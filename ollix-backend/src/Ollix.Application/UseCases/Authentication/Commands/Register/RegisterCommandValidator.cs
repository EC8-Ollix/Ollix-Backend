using FluentValidation;
using Ollix.Application.UseCases.Clients.Commands.CreateClient;
using Ollix.SharedKernel.Extensions;

namespace Ollix.Application.UseCases.Authentication.Commands.Register
{
    internal sealed class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("O Nome é obrigatório")
                .MaximumLength(100).WithMessage("O Nome deve ter no máximo 100 caracteres");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("O Sobrenome é obrigatório")
                .MaximumLength(200).WithMessage("O Sobrenome deve ter no máximo 200 caracteres");

            RuleFor(p => p.UserEmail)
                .NotEmpty().WithMessage("O Email é obrigatório")
                .EmailAddress().WithMessage("O Email está Inválido!");

            RuleFor(p => p.UserPassword)
                .NotEmpty().WithMessage("A Senha é obrigatório")
                .MinimumLength(8).WithMessage("Sua Senha deve ter pelo menos 8 caracteres")
                .MaximumLength(20).WithMessage("Sua Senha deve ter no máximo 20 caracteres")
                .Must(password => password.ContainsUppercase()).WithMessage("Sua Senha deve conter pelo menos uma letra maiúscula")
                .Must(password => password.ContainsLowercase()).WithMessage("Sua Senha deve conter pelo menos uma letra minúscula")
                .Must(password => password.ContainsNumber()).WithMessage("Sua Senha deve conter pelo menos um número")
                .Must(password => password.ContainsSpecialCharacter()).WithMessage("Sua senha deve conter pelo menos um caractere especial");

            RuleFor(p => p.CreateClientCommand)
                .SetValidator(new CreateClientCommandValidator());
        }
    }
}
