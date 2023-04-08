using BlazorShop.Server.Middlewares;

namespace BlazorShop.Server.Extensions;

public static class ApplicationExtensions
{
    public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
    {
        if (app == null)
            throw new ArgumentNullException(nameof(app));

        app.UseMiddleware<GlobalExceptionHandler>();

        return app;
    }
}