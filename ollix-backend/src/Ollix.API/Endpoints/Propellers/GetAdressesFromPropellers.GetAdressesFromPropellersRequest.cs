using Microsoft.AspNetCore.Mvc;
using Ollix.Domain.Aggregates.OrderAggregate;
using Ollix.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Ollix.API.Endpoints.Propellers
{
    public class GetAdressesFromPropellersRequest
    {
        [FromQuery]
        [Required(ErrorMessage = "Informe os dados de Paginação")]
        public PaginationRequest? PaginationRequest { get; set; }

        [Required]
        public Guid ClientId { get; set; }

        public string? State { get; set; }
        public string? City { get; set; }
    }
}
