namespace base_asp;

public class Program
{
    public static readonly string answer = "Hey gey";
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        uint count = 0;
        app.Map(
            "/counter", appBuidler =>
            {
                appBuidler.Use(async (context, next) =>
                {
                    count++;
                    await next();
                });

                appBuidler.Run(async (context) => await context.Response.WriteAsync(count.ToString()));
            }
        );
        app.Run(async (context) => await context.Response.SendFileAsync("index.html"));

        app.Run();
    }
}
