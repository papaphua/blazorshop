using BlazorShop.Server.Middlewares;

namespace BlazorShop.Server.Common.Extensions;

public static class ApplicationExtensions
{
    public static IApplicationBuilder UseExceptionManager(this IApplicationBuilder app)
    {
        if (app == null)
            throw new ArgumentNullException(nameof(app));

        app.UseMiddleware<ExceptionManager>();

        return app;
    }
}