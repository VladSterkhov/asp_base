using Middlewares;

namespace Extensions;

public static class RouteExtensions
{
    public static IApplicationBuilder UseRoute(this IApplicationBuilder builder)
    {
        builder.UseMiddleware<RouteMiddlewares>();
        builder.Map("/counter", appBuilder =>
        {
            appBuilder.Run(async (context) =>
            {
                context.Response.StatusCode = 200;
                await context.Response.WriteAsync("2");
            });
        });
        builder.Map("/index", appBuilder =>
        {
            appBuilder.Run(async (context) =>
            {
                await context.Response.SendFileAsync("index.html");
            });
        });
        return builder;
    }
}