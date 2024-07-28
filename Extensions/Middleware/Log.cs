using Middlewares;

namespace Extensions;

public static class LogExtensions
{
    public static IApplicationBuilder UseLogger(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<LogMiddleware>();
    }
}