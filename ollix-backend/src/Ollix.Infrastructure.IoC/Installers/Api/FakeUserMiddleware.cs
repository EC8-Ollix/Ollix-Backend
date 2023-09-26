using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Infrastructure.IoC.Installers.Api;

public class FakeUserMiddleware
{
    private readonly RequestDelegate _next;

    public FakeUserMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        // Simula a obtenção do UserId do usuário logado
        Guid userId = Guid.NewGuid();

        // Adiciona o UserId ao Items do HttpContext
        httpContext.Items["UserId"] = userId;

        // Passa o controle para o próximo middleware
        await _next(httpContext);
    }
}

