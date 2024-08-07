using Logs;

namespace Extensions;

public static class LogServiceExtensions
{
    public static void AddLogger(this IServiceCollection services)
    {
        services.AddTransient<Logs.ILogger, LogWriter>();
        services.AddTransient<CustomLogs>();
    }
}