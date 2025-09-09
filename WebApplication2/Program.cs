var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    // context.Request

    await context.Response.WriteAsync("The method is: {context.Request.Method}");
    await context.Response.WriteAsync("The Url is : {context.");

    await context.Response.WriteAsync($"\r\nHeaders:r\n");

    foreach(var key in context.Request.Headers.Keys)
    {
        await context.Response.WriteAsync($"{key}:{ context.Request.Headers[key]}\r\n");

    }
});

app.Run();
