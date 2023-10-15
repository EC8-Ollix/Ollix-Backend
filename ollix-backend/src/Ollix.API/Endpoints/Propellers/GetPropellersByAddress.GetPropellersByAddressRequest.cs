using Microsoft.AspNetCore.Mvc;
using Ollix.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Ollix.API.Endpoints.Propellers
{
    public class GetPropellersByAddressRequest
    {
        [FromQuery]
        [Required(ErrorMessage = "Informe os dados de Paginação")]
        public PaginationRequest? PaginationRequest { get; set; }

        [Required]
        public Guid ClientId { get; set; }
        [Required]
        public Guid AddressId { get; set; }

        public Guid OrderId { get; set; }
        public bool? Active { get; set; }
        public bool? Installed { get; set; }
    }
}
