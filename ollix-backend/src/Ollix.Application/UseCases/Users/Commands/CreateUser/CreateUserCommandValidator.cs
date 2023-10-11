using FluentValidation;
using Ollix.Application.UseCases.Users.Commands.Shared;
using Ollix.SharedKernel.Extensions;
using System;

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

