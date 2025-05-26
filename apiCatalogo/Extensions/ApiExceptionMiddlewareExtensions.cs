using System;
using System.Net;
using apiCatalogo.Models;
using Microsoft.AspNetCore.Diagnostics;

namespace apiCatalogo.Extensions;

/// <summary>
/// Classe de extenção
/// </summary>
public static class ApiExceptionMiddlewareExtensions
{
    /// <summary>
    /// Método de extenção para IApplicationBuilder
    /// </summary>
    /// <param name="app"></param>
    public static void ConfigureExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                if (contextFeature != null)
                {
                    await context.Response.WriteAsync(new ErrorDetails()
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = contextFeature.Error.Message,
                        Trace = contextFeature.Error.StackTrace
                    }.ToString());
                }
            });
        });
    }
}
