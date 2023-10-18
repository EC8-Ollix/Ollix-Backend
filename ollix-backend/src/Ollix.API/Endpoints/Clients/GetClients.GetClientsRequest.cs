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
    }
}
