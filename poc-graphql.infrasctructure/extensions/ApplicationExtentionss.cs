using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using poc_graphql.application.dto.error;
using poc_graphql.application.exceptions;
using System.Text.Json;

namespace poc_graphql.infrasctructure.extensions
{
    public static class ApplicationExtentions
    {
        public static IApplicationBuilder ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    int statusCode = 500;
                    string message = "Ocurrió un error inesperado.";
                    string stackTrace = null;

                    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                    var exception = exceptionHandlerPathFeature?.Error;

                    if (exception != null)
                    {
                        if (exception is BaseCustomException customException)
                        {
                            statusCode = customException.Code;
                            message = customException.Message;
                            stackTrace = customException.StackTrace;
                        }

                        else if (exception is ArgumentException || exception.Message.Contains("invalid_token"))
                        {
                            context.Response.Headers.Add("Token-Valid", "false");
                        }
                    }
                    var response = new ErrorDto
                    {
                        code = statusCode,
                        message = message,
                        error = true,
                    };

                    var jsonResponse = JsonSerializer.Serialize(response);
                    context.Response.StatusCode = statusCode;
                    await context.Response.WriteAsync(jsonResponse);
                });
            });
            return app;
        }
    }
}
