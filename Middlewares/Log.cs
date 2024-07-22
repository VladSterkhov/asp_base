using Logs;

namespace Middlewares;

public class LogMiddleware
{
    private RequestDelegate next;

    public LogMiddleware(RequestDelegate next) => this.next = next;

    public async Task Invoke(HttpContext context)
    {
        LogWriter logger = new();
        CustomLogs customLogs = new(logger);
        customLogs.PrintLog(context.Request.Method);
        await next.Invoke(context);
    }
}