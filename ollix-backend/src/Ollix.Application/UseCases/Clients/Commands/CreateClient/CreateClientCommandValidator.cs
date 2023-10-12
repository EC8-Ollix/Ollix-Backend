using FluentValidation;
using Ollix.Application.UseCases.Clients.Commands.Shared;
using Ollix.Application.UseCases.Users.Commands.Shared;
using Ollix.SharedKernel.Extensions;

namespace Ollix.Application.UseCases.Clients.Commands.CreateClient
{
    internal sealed class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
    {
        public CreateClientCommandValidator()
        {
            Include(new UpsertClientCommandValidator());

            RuleFor(p => p.Cnpj)
                .NotEmpty().WithMessage("O CNPJ da Empresa é obrigatório")
                .Length(14, 14).WithMessage("O CNPJ deve conter apenas 14 caracteres")
                .Must(r => r.IsValidCnpj()).WithMessage("O CNPJ informado está Inválido")
                .When(r => r is not null);
        }
    }
}
