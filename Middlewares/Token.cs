namespace Middlewares;

class TokenMidleware
{
    private readonly RequestDelegate next;
    private string pattern;

    public TokenMidleware(RequestDelegate next, string pattern)
    {
        this.next = next;
        this.pattern = pattern;
    }

    public async Task Invoke(HttpContext context)
    {
        var token = context.Request.Query["token"];
        if (token == pattern)
        {
            Console.WriteLine(token);
            await next.Invoke(context);
        }
        else
        {
            context.Response.StatusCode = 403;
        }
    }
}