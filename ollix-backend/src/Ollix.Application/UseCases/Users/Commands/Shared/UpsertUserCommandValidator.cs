﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ollix.SharedKernel.Extensions;

namespace Ollix.Application.UseCases.Users.Commands.Shared
{
    internal sealed class UpsertUserCommandValidator : AbstractValidator<UpsertUserCommand>
    {
        public UpsertUserCommandValidator()
        {
            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("O Nome é obrigatório")
                .MaximumLength(100).WithMessage("O Nome deve ter no máximo 100 caracteres");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("O Sobrenome é obrigatório")
                .MaximumLength(200).WithMessage("O Sobrenome deve ter no máximo 200 caracteres");

            RuleFor(p => p.UserPassword)
                .NotEmpty().WithMessage("A Senha é obrigatório")
                .MinimumLength(8).WithMessage("Sua Senha deve ter pelo menos 8 caracteres")
                .MaximumLength(20).WithMessage("Sua Senha deve ter no máximo 20 caracteres")
                .Must(password => password.ContainsUppercase()).WithMessage("Sua Senha deve conter pelo menos uma letra maiúscula")
                .Must(password => password.ContainsLowercase()).WithMessage("Sua Senha deve conter pelo menos uma letra minúscula")
                .Must(password => password.ContainsNumber()).WithMessage("Sua Senha deve conter pelo menos um número")
                .Must(password => password.ContainsSpecialCharacter()).WithMessage("Sua senha deve conter pelo menos um caractere especial");

            RuleFor(p => p.UserInfo)
                .NotEmpty().WithMessage("O Usuário é obrigatório");
        }
    }
}
