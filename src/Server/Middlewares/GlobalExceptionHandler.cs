using System.Net;
using BlazorShop.Server.Common.Exceptions;
using BlazorShop.Shared.Dtos;

namespace BlazorShop.Server.Middlewares;

public class GlobalExceptionHandler : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (BusinessException exception)
        {
            context.Response.StatusCode = exception switch
            {
                AlreadyExistException => (int)HttpStatusCode.Conflict,
                NotFoundException => (int)HttpStatusCode.NotFound,
                _ => (int)HttpStatusCode.BadRequest
            };

            context.Response.ContentType = "application/json";

            await context.Response.WriteAsJsonAsync(new ExceptionDto(exception.Message));
        }
    }
}