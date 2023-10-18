namespace Ollix.Application.UseCases.Clients.Commands.Shared
{
    public record UpsertClientCommand
    {
        public string? CompanyName { get; set; }
        public string? BussinessName { get; set; }
    }
}
