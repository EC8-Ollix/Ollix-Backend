using FluentValidation;
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

            RuleFor(p => p.UserInfo)
                .NotEmpty().WithMessage("O Usuário é obrigatório");
        }
    }
}
