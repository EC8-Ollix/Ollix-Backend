using Microsoft.AspNetCore.Mvc;
using Ollix.Domain.Aggregates.LogAggregate;
using Ollix.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Ollix.API.Endpoints.Logs
{
    public class GetLogsRequest
    {
        [FromQuery]
        [Required(ErrorMessage = "Informe os dados de Paginação")]
        public PaginationRequest? PaginationRequest { get; set; }
        public Guid ClientId { get; set; }
        public EntityEnum Entity { get; set; }
        public OperationEnum Operation { get; set; }
        public string? UserName { get; set; }
        public DateTimeOffset RequestedDateFrom { get; set; }
        public DateTimeOffset RequestedDateTo { get; set; }
    }
}
