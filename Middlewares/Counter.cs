namespace middlewares;

public class CounterMiddleware
{
    private readonly RequestDelegate next;
    public CounterMiddleware( RequestDelegate next) => this.next = next;
    
    public async Task InvokeAsync (HttpContext context)
    {
        Console.WriteLine(context.Request.Host.ToString());
        await next.Invoke(context);
    }
}