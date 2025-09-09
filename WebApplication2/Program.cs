var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    // context.Request
    if (context.Request.Method == "GET")
    {
        if (context.Request.Path.StartsWithSegments("/"))
        {
            await context.Response.WriteAsync("The method is: {context.Request.Method}");
            await context.Response.WriteAsync("The Url iss : {context.");

            await context.Response.WriteAsync($"\r\nHeaders:r\n");

            foreach (var key in context.Request.Headers.Keys)
            {
                await context.Response.WriteAsync($"{key}:{context.Request.Headers[key]}\r\n");

            }
        }
        else if (context.Request.Path.StartsWithSegments("/employees"))
        {
            await context.Response.WriteAsync("Employees List");
        }
    }
    
});

app.Run();
