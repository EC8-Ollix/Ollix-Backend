using Ardalis.Result;
using Ollix.API.Shared.Request;
using Ollix.Application.UseCases.Orders.Commands.CreateOrder;
using Ollix.Domain.Aggregates.OrderAggregate;
using Ollix.SharedKernel.Extensions;

namespace Ollix.API.Endpoints.Orders
{
    public class CreateOrderRequest : IApiRequest<CreateOrderCommand, Result<Order>>
    {
        public string? RequesterName { get; set; }
        public string? RequesterEmail { get; set; }
        public string? Observation { get; set; }
        public int QuantityRequested { get; set; }
        public string? PostalCode { get; set; }

        public CreateOrderCommand ToCommand()
        {
            return new CreateOrderCommand()
            {
                RequesterName = RequesterName,
                RequesterEmail = RequesterEmail,
                Observation = Observation,
                QuantityRequested = QuantityRequested,
                PostalCode = PostalCode.JustNumbers(),
            };
        }
    }

}
