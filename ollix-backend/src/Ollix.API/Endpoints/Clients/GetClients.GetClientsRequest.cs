using Microsoft.AspNetCore.Mvc;
using Ollix.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Ollix.API.Endpoints.Clients
{
    public class GetClientsRequest
    {
        [FromQuery]
        [Required(ErrorMessage = "Informe os dados de Paginação")]
        public PaginationRequest? PaginationRequest { get; set; }

        public string? CompanyName { get; set; }
        public string? BussinessName { get; set; }
        public string? Cnpj { get; set; }
        public bool? Active { get; set; }
    }
}
