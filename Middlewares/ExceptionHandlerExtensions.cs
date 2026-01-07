using Edward.GlobalExceptionHandler.Codes;
using Edward.GlobalExceptionHandler.Exceptions;
using Edward.GlobalExceptionHandler.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace Edward.GlobalExceptionHandler.Middlewares
{
    public static class ExceptionHandlerExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
                    context.Response.ContentType = "application/json";

                    ApiResponse response;

                    switch (exception)
                    {
                        case ValidationException ve:
                            context.Response.StatusCode = StatusCodes.Status400BadRequest;
                            response = ApiResponse.Fail(ErrorCodes.ValidationError, ve.Message);
                            break;

                        case NotFoundException ne:
                            context.Response.StatusCode = StatusCodes.Status404NotFound;
                            response = ApiResponse.Fail(ErrorCodes.NotFound, ne.Message);
                            break;

                        case BusinessException be:
                            context.Response.StatusCode = StatusCodes.Status409Conflict;
                            response = ApiResponse.Fail(ErrorCodes.BusinessError, be.Message);
                            break;

                        default:
                            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                            response = ApiResponse.Fail(ErrorCodes.InternalError, exception?.Message ?? "未知错误");
                            break;
                    }

                    await context.Response.WriteAsJsonAsync(response);
                });
            });

            return app;
        }
    }
}
