namespace Middlewares;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate next;

    public ErrorHandlingMiddleware(RequestDelegate next) => this.next = next;

    public async Task Invoke(HttpContext context)
    {
        await next.Invoke(context);
        if(context.Response.StatusCode == 403)
        {
            await context.Response.WriteAsync("Access denied");
        }
        else if (context.Response.StatusCode == 404)
        {
            await context.Response.WriteAsync("Not found");
        }
    }
}