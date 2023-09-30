using Ollix.Infrastructure.IoC;


namespace Ollix.API.AppInitializer.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder Run(this WebApplicationBuilder builder)
        {
            builder.Services.InstallServices(builder.Configuration, typeof(Infrastructure.IoC.AssemblyReference).Assembly);

            var app = builder.Build();

            app.UseServices(app.Environment, builder.Configuration);

            app.Run();

            return builder;
        }
    }
}
