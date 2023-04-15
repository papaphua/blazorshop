using BlazorShop.Server.Common;
using BlazorShop.Server.Common.Exceptions;
using BlazorShop.Shared.Dtos;

namespace BlazorShop.Server.Middlewares;

public sealed class ExceptionManager
{
    private readonly RequestDelegate _next;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ExceptionManager(RequestDelegate next, IWebHostEnvironment webHostEnvironment)
    {
        _next = next;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            context.Response.StatusCode = exception switch
            {
                AlreadyExistException => StatusCodes.Status409Conflict,
                NotFoundException => StatusCodes.Status404NotFound,
                BusinessException => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError
            };

            var response = new ExceptionDto();

            if (_webHostEnvironment.IsDevelopment())
                response.Message = exception.Message;
            else
                response.Message = exception is BusinessException
                    ? exception.Message
                    : ExceptionMessages.InternalServerError;

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}