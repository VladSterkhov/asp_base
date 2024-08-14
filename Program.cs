using Extensions;

namespace base_asp;

public class Program
{
    public static uint count = 0;
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddTimeService(); 
        builder.Services.AddLogger();

        var app = builder.Build();
        app.Environment.EnvironmentName = "Development";

        app.UseLogger();
        app.UseErrorHandling();
        app.UseToken("12345");
        app.UseRoute(count);
        
        app.Run(async (context) => await context.Response.SendFileAsync("index.html"));
        app.Run();
    }
}
