using Ardalis.Result;
using Microsoft.AspNetCore.Mvc;
using Ollix.API.Shared.Request;
using Ollix.Application.Shared;
using Ollix.Application.UseCases.Clients.Commands.CreateClient;
using Ollix.Domain.Aggregates.ClientAppAggregate;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Ollix.API.Endpoints.Clients
{
    public class UpdateClientRequest : IApiRequest<UpdateClientCommand, Result<ClientApp>>
    {
        public string? CompanyName { get; set; }
        public string? BussinessName { get; set; }

        [FromRoute(Name = "clientId")]
        [FromQuery]
        [Required]
        public Guid ClientId { get; set; }

        public UpdateClientCommand ToCommand()
        {
            return new UpdateClientCommand()
            {
                BussinessName = BussinessName,
                CompanyName = CompanyName,
            };
        }
    }
}
