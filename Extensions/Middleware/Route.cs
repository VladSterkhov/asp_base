using System.Text;
using Middlewares;
using Time;

namespace Extensions;

public static class RouteExtensions
{
    public static IApplicationBuilder UseRoute(this IApplicationBuilder builder, uint count)
    {
        builder.UseMiddleware<RouteMiddlewares>();

#pragma warning disable  // Possible null reference argument.

        TimeMessage currentTime = new(builder.ApplicationServices.GetService<TimeService>());
#pragma warning restore  // Possible null reference argument.


        builder.Map("/counter", appBuilder =>
        {
            appBuilder.Run(async (context) =>
            {
                count ++;
                context.Response.StatusCode = 200;
                context.Response.ContentType = "text/html;charset=utf-8";
                await context.Response.WriteAsync($"{count}<br>{currentTime?.GetTime()}");
            });
        });
        builder.Map("/index", appBuilder =>
        {
            appBuilder.Run(async (context) =>
            {
                await context.Response.SendFileAsync("index.html");
            });
        });
        builder.Map("/services", appBuilder =>
        {
            #pragma warning disable
            appBuilder.Run(async (context) =>
            #pragma warning restore
            {
                context.Response.ContentType = "text/html;charset=utf-8";
                context.Response.StatusCode = 301;
                context.Response.Redirect("/index?token=" + context.Request.Query["token"]);
            });
        });
        return builder;
    }
}