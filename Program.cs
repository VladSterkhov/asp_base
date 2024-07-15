namespace base_asp;

public class Program
{
    public static readonly string answer = "Hey gey";
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        // app.Run(async (context) =>
        // {
        //     context.Response.ContentType = "text/html; charset=utf-8";
        //     context.Response.Headers.Append("custom-field", "penis");
        //     await context.Response.WriteAsync("<h2>Hello World</h2>");
        // });
        // app.Run(async (context) =>
        // {
        //     context.Response.StatusCode = 404;
        //     await context.Response.WriteAsync("Not found");
        // });
        // app.Run(async (context) =>
        // {
        //     context.Response.ContentType = "application/json; charset=utf-8";
        //     context.Response.Headers.Append("custom-field", "penis");
        //     await context.Response.WriteAsJsonAsync(new { name = "русский" });
        // });
        app.Run(async (context) =>
        {
            // context.Response.ContentType = "application/json; charset=utf-8";
            // context.Response.Headers.Append("custom-field", "penis");
            if(context.Request.Path == "/file")
            {
                await context.Response.SendFileAsync("Ilnaz_spider.jpeg");
            }
            else if(context.Request.Path == "/fileload")
            {
                context.Response.Headers.ContentDisposition = "attachment; filename=Ilnaz_spider.jpeg";
                await context.Response.SendFileAsync("Ilnaz_spider.jpeg");
            }
            else if(context.Request.Path == "/report_data/23")
            {
                context.Response.Headers.ContentDisposition = "attachment; filename=image.png";
                await context.Response.SendFileAsync("image.png");
            }
            else if(context.Request.Path == "/html")
            {
                await context.Response.SendFileAsync("index.html");
            }
            else if(context.Request.Path == "/postQuery")
            {
                var form = context.Request.Form;
                await context.Response.WriteAsJsonAsync(new { Name = form["name"], Age = form["age"]});
            }
            else 
            {
                await context.Response.WriteAsync($"Path: {context.Request.Path}");
            }
        });

        app.Run();
    }
}
