using Microsoft.Extensions.Configuration;
using Ollix.Infrastructure.IoC.Configs.Options;

namespace Ollix.Infrastructure.IoC.Extensions
{
    public static class ConfigurationExtensions
    {
        public static string? GetApiName(this IConfiguration configuration)
        {
            var env = configuration.GetSection("EnviromentSettings").Get<EnviromentSettings>();

            return env is not null ? env.ApiName : throw new Exception("EnviromentSettings não definido");
        }

        public static JwtSettings? GetJwtSettings(this IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection(nameof(JwtSettings)).Get<JwtSettings>();

            return jwtSettings is not null ? jwtSettings : throw new Exception("jwtSettings não definido");
        }
    }
}
