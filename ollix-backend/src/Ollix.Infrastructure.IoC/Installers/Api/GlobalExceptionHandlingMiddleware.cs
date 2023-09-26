using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ollix.Infrastructure.IoC.Installers.Api
{
    internal class GlobalExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

        public GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                _logger.LogCritical(e, e.Message);

                var httpCode = (int)HttpStatusCode.InternalServerError;

                context.Response.StatusCode = httpCode;

                string json = JsonSerializer.Serialize(new ProblemDetails()
                {
                    Status = httpCode,
                    Type = "Server Error",
                    Title = "Um erro inesperado ocorreu!",
                    Detail = "Um erro inesperado ocorreu!",
                });

                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(json);
            }
        }
    }
}
