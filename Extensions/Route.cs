using System.Text;
using Middlewares;
using Time;

namespace Extensions;

public static class RouteExtensions
{
    public static IApplicationBuilder UseRoute(this IApplicationBuilder builder, uint count, IServiceCollection services)
    {
        builder.UseMiddleware<RouteMiddlewares>();
        var timeService = builder.ApplicationServices.GetService<ITimeService>();
        builder.Map("/counter", appBuilder =>
        {
            appBuilder.Run(async (context) =>
            {
                count ++;
                context.Response.StatusCode = 200;
                await context.Response.WriteAsync($"{count} {timeService?.GetTime()}");
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
            appBuilder.Run(async (context) =>
            {
                StringBuilder sb = new();
                sb.Append("<ul>");
                foreach(var service in services)
                {
                    sb.Append($"<li>{service.ServiceType.FullName}</li>");
                }
                sb.Append("</ul>");
                context.Response.ContentType = "text/html;charset=utf-8";
                await context.Response.WriteAsync(sb.ToString());
            });
        });
        return builder;
    }
}