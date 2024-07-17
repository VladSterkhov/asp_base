namespace Middlewares;

public class RouteMiddlewares
{
    private readonly RequestDelegate next;

    private List<string> routeMap = new List<string>{"/index", "/counter"};

    public RouteMiddlewares(RequestDelegate next) => this.next = next;

    public async Task Invoke(HttpContext context)
    {
        if(routeMap.Contains(context.Request.Path))
        {
            context.Response.StatusCode = 200;
            await next.Invoke(context);
        }
        else 
        {
            context.Response.StatusCode = 404;
        }
    }
}