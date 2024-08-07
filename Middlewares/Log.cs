using System.Text;
using Logs;

namespace Middlewares;

public class LogMiddleware
{
    private RequestDelegate next;

    public LogMiddleware(RequestDelegate next) => this.next = next;

    public async Task Invoke(HttpContext context)
    {
        var logger = context.RequestServices.GetRequiredService<CustomLogs>();
        StringBuilder stringBuilder = new();
        foreach(var param in context.Request.Query)
        {
            stringBuilder.Append(param);
        }
        logger.PrintLog(stringBuilder.ToString());
        await next.Invoke(context);
    }
}