namespace Ollix.Infrastructure.Integrations.ViaCep
{
    public record ViaCepModelResponse(
        string Cep,
        string Logradouro,
        string Complemento,
        string Bairro,
        string Localidade,
        string Uf,
        string Ibge,
        string Gia,
        string Ddd,
        string Siafi);
}
