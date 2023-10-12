using FluentValidation;
using Ollix.Application.UseCases.Users.Commands.Shared;

namespace Ollix.Application.UseCases.Users.Commands.CreateUser
{
    internal sealed class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            Include(new UpsertUserCommandValidator());
        }
    }
}

