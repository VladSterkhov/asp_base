using Extensions;
using Time;

namespace base_asp;

public class Program
{
    public static uint count = 0;
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        IServiceCollection allServices = builder.Services;
        allServices.AddTransient<ITimeService, ShortTimeService>();

        var app = builder.Build();
        app.Environment.EnvironmentName = "Development";

        app.UseLogger();
        app.UseErrorHandling();
        app.UseToken("12345");
        app.UseRoute(count, allServices);
        
        app.Run(async (context) => await context.Response.SendFileAsync("index.html"));
        app.Run();
    }
}
