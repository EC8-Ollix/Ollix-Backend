using FluentValidation;

namespace Ollix.Application.UseCases.Authentication.Commands.Login
{
    internal sealed class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(p => p.UserEmail)
                .NotEmpty().WithMessage("O Email é obrigatório")
                .EmailAddress().WithMessage("O Email está Inválido!");

            RuleFor(p => p.UserPassword)
                .NotEmpty().WithMessage("A Senha é obrigatório");
        }
    }
}
