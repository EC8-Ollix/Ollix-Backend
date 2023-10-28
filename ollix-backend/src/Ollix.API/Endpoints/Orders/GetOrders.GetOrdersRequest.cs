using Microsoft.AspNetCore.Mvc;
using Ollix.Domain.Aggregates.OrderAggregate;
using Ollix.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Ollix.API.Endpoints.Orders
{
    public class GetOrdersRequest
    {
        [FromQuery]
        [Required(ErrorMessage = "Informe os dados de Paginação")]
        public PaginationRequest? PaginationRequest { get; set; }
        public Guid ClientId { get; set; }
        public string? OrderNumber { get; set; }
        public string? ClientSearch { get; set; }
        public string? RequesterSearch { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTimeOffset RequestedDateFrom { get; set; }
        public DateTimeOffset RequestedDateTo { get; set; }
    }
}
