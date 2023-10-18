using FluentValidation;
using Ollix.Application.UseCases.Clients.Commands.Shared;

namespace Ollix.Application.UseCases.Clients.Commands.CreateClient
{
    internal sealed class UpdateClientCommandValidator : AbstractValidator<UpdateClientCommand>
    {
        public UpdateClientCommandValidator()
        {
            Include(new UpsertClientCommandValidator());

            RuleFor(p => p.ClientId)
                .NotEmpty()
                .WithMessage("O Cliente é obrigatório");

            RuleFor(p => p.UserInfo)
                .NotEmpty()
                .WithMessage("O Usuário é obrigatório");
        }
    }
}
