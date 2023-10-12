using Microsoft.AspNetCore.Mvc;
using Ollix.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Ollix.API.Endpoints.Logs
{
    public class GetLogsRequest
    {
        [FromQuery]
        [Required(ErrorMessage = "Informe os dados de Paginação")]
        public PaginationRequest? PaginationRequest { get; set; }
        public string? ClientId { get; set; }
    }
}
