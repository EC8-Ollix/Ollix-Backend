using FluentValidation;
using Ollix.SharedKernel.Extensions;
using System;

namespace Ollix.Application.UseCases.Authentication.Commands.Register
{
    internal class RegisterCommandValidator : AbstractValidator<RegisterCommand>
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
                .MinimumLength(5).WithMessage("O Email deve ter no minimo 5 caracteres")
                .MaximumLength(200).WithMessage("O Email deve ter no máximo 200 caracteres")
                .Matches("@\"^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$").WithMessage("Email Inválido!");

            RuleFor(p => p.UserPassword)
                .NotEmpty().WithMessage("A Senha é obrigatório")
                .MinimumLength(8).WithMessage("Sua Senha deve ter pelo menos 8 caracteres")
                .MaximumLength(20).WithMessage("Sua Senha deve ter no máximo 20 caracteres")
                .Must(password => password.ContainsUppercase()).WithMessage("Sua Senha deve conter pelo menos uma letra maiúscula")
                .Must(password => password.ContainsLowercase()).WithMessage("Sua Senha deve conter pelo menos uma letra minúscula")
                .Must(password => password.ContainsNumber()).WithMessage("Sua Senha deve conter pelo menos um número")
                .Must(password => password.ContainsSpecialCharacter()).WithMessage("Sua senha deve conter pelo menos um caractere especial");

            RuleFor(p => p.CreateClientCommand)
                .NotEmpty().WithMessage("Os campos da Empresa são obrigatórios");

            RuleFor(p => p.CreateClientCommand.BussinessName)
                .NotEmpty().WithMessage("O Nome da Empresa é obrigatório")
                .MaximumLength(400).When(r => r.CreateClientCommand != null).WithMessage("O Nome da Empresa deve ter no máximo 400 caracteres");

            RuleFor(p => p.CreateClientCommand.CompanyName)
                .NotEmpty().WithMessage("O Nome Fantasia da Empresa é obrigatório")
                .MaximumLength(400).When(r => r.CreateClientCommand != null).WithMessage("O Nome Fantasia da Empresa deve ter no máximo 400 caracteres");

            RuleFor(p => p.CreateClientCommand.Cnpj)
                .NotEmpty().WithMessage("O CNPJ da Empresa é obrigatório")
                .Length(14, 14).WithMessage("O CNPJ deve conter apenas 14 caracteres")
                .Must(r => r.IsValidCnpj()).When(r => r.CreateClientCommand != null).WithMessage("O CNPJ informado está Inválido");

        }
    }

    internal class PasswordValidator : AbstractValidator<RegisterCommand>
    {
        public PasswordValidator()
        {

        }
    }
}
