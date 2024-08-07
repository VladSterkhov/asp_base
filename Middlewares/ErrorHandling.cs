using Time;

namespace Middlewares;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate next;

    public ErrorHandlingMiddleware(RequestDelegate next) => this.next = next;

    public async Task Invoke(HttpContext context)
    {
        var timeService = context.RequestServices.GetService<ITimeService>();
        await next.Invoke(context);
        if(context.Response.StatusCode == 403)
        {
            await context.Response.WriteAsync($"Access denied. Time:{timeService?.GetTime()}");
        }
        else if (context.Response.StatusCode == 404)
        {
            await context.Response.WriteAsync($"Not found. Time:{timeService?.GetTime()}");
        }
    }
}