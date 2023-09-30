using Microsoft.Extensions.Configuration;
using Ollix.Infrastructure.IoC.Configs;

namespace Ollix.Infrastructure.IoC.Extensions
{
    public static class ConfigurationExtensions
    {
        public static string? GetApiName(this IConfiguration configuration)
        {
            var env = configuration.GetSection("EnviromentSettings").Get<EnviromentSettings>();

            return env is not null ? env.ApiName : throw new Exception("EnviromentSettings não definido");
        }
    }
}
