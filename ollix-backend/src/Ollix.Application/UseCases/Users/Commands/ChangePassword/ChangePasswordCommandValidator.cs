using FluentValidation;
using Ollix.Application.UseCases.Users.Commands.CreateUser;
using Ollix.Application.UseCases.Users.Commands.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ollix.SharedKernel.Extensions;

namespace Ollix.Application.UseCases.Users.Commands.ChangePassword
{
    internal class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordCommandValidator()
        {
            RuleFor(p => p.CurrentPassword)
                .NotNull().WithMessage("A Senha atual é obrigatória")
                .NotEmpty().WithMessage("A Senha atual é obrigatória");

            RuleFor(p => p.NewPassword)
                .NotNull().WithMessage("A Senha é obrigatório")
                .NotEmpty().WithMessage("A Senha é obrigatório")
                .MinimumLength(8).WithMessage("Sua Senha deve ter pelo menos 8 caracteres")
                .MaximumLength(20).WithMessage("Sua Senha deve ter no máximo 20 caracteres")
                .Must(password => password.ContainsUppercase()).WithMessage("Sua Senha deve conter pelo menos uma letra maiúscula")
                .Must(password => password.ContainsLowercase()).WithMessage("Sua Senha deve conter pelo menos uma letra minúscula")
                .Must(password => password.ContainsNumber()).WithMessage("Sua Senha deve conter pelo menos um número")
                .Must(password => password.ContainsSpecialCharacter()).WithMessage("Sua senha deve conter pelo menos um caractere especial");
        }
    }
}
