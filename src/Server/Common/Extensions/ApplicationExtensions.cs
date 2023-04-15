using BlazorShop.Server.Middlewares;

namespace BlazorShop.Server.Common.Extensions;

public static class ApplicationExtensions
{
    public static void UseExceptionManager(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionManager>();
    }
}