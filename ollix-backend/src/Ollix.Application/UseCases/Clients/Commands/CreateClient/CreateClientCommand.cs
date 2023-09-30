using Ardalis.Result;
using MediatR;
using Ollix.Domain.ClientAppAggregate;

namespace Ollix.Application.UseCases.Clients.Commands.CreateClient
{
    public sealed record CreateClientCommand : IRequest<Result<ClientApp>>
    {
        public string? CompanyName { get; set; }
        public string? BussinessName { get; set; }
        public string? Cnpj { get; set; }
    }
}
