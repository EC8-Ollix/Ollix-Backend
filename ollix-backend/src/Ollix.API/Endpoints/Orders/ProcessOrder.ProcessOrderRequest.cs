using Ardalis.Result;
using Microsoft.AspNetCore.Mvc;
using Ollix.API.Shared.Request;
using Ollix.Application.UseCases.Orders.Commands.ProcessOrder;
using Ollix.Domain.Aggregates.OrderAggregate;
using System.ComponentModel.DataAnnotations;

namespace Ollix.API.Endpoints.Orders
{
    public class ProcessOrderRequest : IApiRequest<ProcessOrderCommand, Result<Order>>
    {
        [FromRoute(Name = "orderId")]
        [Required]
        public Guid OrderId { get; set; }
        public bool Approved { get; set; }
        public DateTimeOffset IntallationDate { get; set; }

        public ProcessOrderCommand ToCommand()
        {
            return new ProcessOrderCommand()
            {
                OrderId = OrderId,
                Approved = Approved,
                IntallationDate = IntallationDate
            };
        }
    }
}
