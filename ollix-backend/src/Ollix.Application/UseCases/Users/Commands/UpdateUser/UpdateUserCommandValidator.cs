using FluentValidation;
using Ollix.Application.UseCases.Users.Commands.Shared;

namespace Ollix.Application.UseCases.Users.Commands.UpdateUser
{
    internal sealed class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            Include(new UpsertUserCommandValidator());

            RuleFor(p => p.UserId)
                .NotEmpty()
                .WithMessage("O Usuário é obrigatório");
        }
    }
}
