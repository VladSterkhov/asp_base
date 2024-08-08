using Logs;

namespace Extensions;

public static class LogServiceExtensions
{
    public static void AddLogger(this IServiceCollection services)
    {
        services.AddScoped<Logs.ILogger, LogWriter>();
        services.AddScoped<CustomLogs>();
    }
}