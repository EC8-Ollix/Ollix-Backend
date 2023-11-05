using Microsoft.AspNetCore.Mvc;
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
        public string? PostalCode { get; set; }
        public string? Street { get; set; }
        public string? Neighborhood { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
    }
}
