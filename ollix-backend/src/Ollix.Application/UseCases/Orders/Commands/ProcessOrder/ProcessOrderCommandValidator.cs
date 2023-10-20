using FluentValidation;

namespace Ollix.Application.UseCases.Orders.Commands.ProcessOrder
{

    internal sealed class ProcessOrderCommandValidator : AbstractValidator<ProcessOrderCommand>
    {
        public ProcessOrderCommandValidator()
        {
            RuleFor(p => p.OrderId)
                .NotEmpty().WithMessage("O Pedido é obrigatório");

            RuleFor(p => p.IntallationDate)
                .GreaterThan(DateTimeOffset.UtcNow.Date).When(p => p.Approved)
                .WithMessage("Necessário informar a Data de Instalação para um Pedido Aprovado");

            RuleFor(p => p.UserInfo)
                .NotEmpty().WithMessage("O Usuário é obrigatório");
        }
    }
}
