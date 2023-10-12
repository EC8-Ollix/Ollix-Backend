using FluentValidation;
using Ollix.SharedKernel.Extensions;

namespace Ollix.Application.UseCases.Clients.Commands.Shared
{
    internal sealed class UpsertClientCommandValidator : AbstractValidator<UpsertClientCommand>
    {
        public UpsertClientCommandValidator()
        {
            RuleFor(p => p)
                .NotEmpty().WithMessage("Os Campos da Empresa são obrigatórios");

            RuleFor(p => p.BussinessName)
                .NotEmpty().WithMessage("O Nome da Empresa é obrigatório")
                .MaximumLength(400).WithMessage("O Nome da Empresa deve ter no máximo 400 caracteres")
                .When(r => r is not null);

            RuleFor(p => p.CompanyName)
                .NotEmpty().WithMessage("O Nome Fantasia da Empresa é obrigatório")
                .MaximumLength(400).WithMessage("O Nome Fantasia da Empresa deve ter no máximo 400 caracteres")
                .When(r => r is not null);
        }
    }
}
