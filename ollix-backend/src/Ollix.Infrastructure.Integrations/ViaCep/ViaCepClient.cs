namespace Ollix.Infrastructure.Integrations.ViaCep
{
    public static class ViaCepClient
    {
        public const string? BaseAddress = "https://viacep.com.br/ws/";

        public static string GetPostalCodeUrl(string postalCode) => $"{postalCode}/json/";
    }
}
