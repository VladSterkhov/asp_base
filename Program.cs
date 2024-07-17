using Extensions;

namespace base_asp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();
        app.Environment.EnvironmentName = "Development";

        app.UseErrorHandling();
        app.UseToken("12345");        
        app.UseRoute();
        
        app.Run(async (context) => await context.Response.SendFileAsync("index.html"));
        app.Run();
    }
}
