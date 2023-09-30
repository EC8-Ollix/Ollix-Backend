using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Ollix.Infrastructure.IoC.Configs;
using Ollix.Infrastructure.IoC.Extensions;
using Ollix.Infrastructure.IoC.Interfaces;

namespace Ollix.Infrastructure.IoC.Installers
{
    public class APIServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<GlobalExceptionHandlingMiddleware>();
            services.AddHttpContextAccessor();
            services.AddControllers(options =>
            {
                options.Conventions.Add(new EndpointConvention());
            }).AddNewtonsoftJson(jsonOptions =>
            {
                jsonOptions.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                jsonOptions.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });

            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = configuration.GetApiName(), Version = "v1" });
                c.EnableAnnotations();
            });
        }
    }
}