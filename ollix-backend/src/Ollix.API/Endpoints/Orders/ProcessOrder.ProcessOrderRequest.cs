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

        [FromBody()]
        public ProcessOrderRequestBody? ProcessOrderBody { get; set; }
        public ProcessOrderCommand ToCommand()
        {
            var bodyRequest = ProcessOrderBody ?? new ProcessOrderRequestBody();
            return new ProcessOrderCommand()
            {
                OrderId = OrderId,
                Approved = bodyRequest.Approved,
                InstallationDate = bodyRequest.InstallationDate
            };
        }
    }

    public class ProcessOrderRequestBody
    {
        public bool Approved { get; set; }
        public DateTimeOffset InstallationDate { get; set; }
    }

}
