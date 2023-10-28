using FluentValidation;

namespace Ollix.Application.UseCases.Orders.Commands.ProcessOrder
{

    internal sealed class ProcessOrderCommandValidator : AbstractValidator<ProcessOrderCommand>
    {
        public ProcessOrderCommandValidator()
        {
            RuleFor(p => p.OrderId)
                .NotEmpty().WithMessage("O Pedido é obrigatório");

            RuleFor(p => p.InstallationDate)
                .NotEmpty().WithMessage("Necessário informar a data de instalação para um pedido aprovado")
                .GreaterThan(DateTimeOffset.UtcNow.Date).When(p => p.Approved)
                .WithMessage("Necessário informar uma a data de instalação maior do que hoje");

            RuleFor(p => p.UserInfo)
                .NotEmpty().WithMessage("O Usuário é obrigatório");
        }
    }
}
