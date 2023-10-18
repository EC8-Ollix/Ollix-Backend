using FluentValidation;

namespace Ollix.Application.UseCases.Orders.Commands.CreateOrder
{
    internal sealed class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(p => p.RequesterName)
                .NotEmpty().WithMessage("O Nome é obrigatório")
                .MaximumLength(200).WithMessage("O Nome deve ter no máximo 200 caracteres");

            RuleFor(p => p.RequesterEmail)
                .NotEmpty().WithMessage("O Email é obrigatório")
                .MaximumLength(200).WithMessage("O Nome deve ter no máximo 200 caracteres");

            RuleFor(p => p.Observation)
                .MaximumLength(600).WithMessage("A observação deve ter no máximo 600 caracteres");

            RuleFor(p => p.QuantityRequested)
                .GreaterThan(0).WithMessage("A quantidade solicitada deve ser maior que 0");

            RuleFor(p => p.PostalCode)
                .NotEmpty().WithMessage("O Código do CEP é obrigatório")
                .MaximumLength(8).WithMessage("O CEP deve ter no máximo 8 caracteres");

            RuleFor(p => p.UserInfo)
                .NotEmpty().WithMessage("O Usuário é obrigatório");
        }
    }
}
