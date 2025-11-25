var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var port = Environment.GetEnvironmentVariable("PORT") ?? "80";
var name = Environment.GetEnvironmentVariable("NAME") ?? "unnamed";
var url = $"http://0.0.0.0:{port}";

app.MapGet("/{**ok}", async (HttpContext context) =>
{
    var request = context.Request;

    var ip = context.Connection.RemoteIpAddress?.ToString();
    var method = request.Method;
    var scheme = request.Scheme;
    var host = request.Host.Value;
    var path = request.Path;
    var queryString = request.QueryString.Value;
    var headers = request.Headers;

    var responseText = new System.Text.StringBuilder();
    responseText.AppendLine("<pre>");
    responseText.AppendLine($"Server Name: {name}");
    responseText.AppendLine($"IP Address: {ip}");
    responseText.AppendLine($"Method: {method}");
    responseText.AppendLine($"Scheme: {scheme}");
    responseText.AppendLine($"Host: {host}");
    responseText.AppendLine($"Path: {path}");
    responseText.AppendLine($"QueryString: {queryString}");
    responseText.AppendLine("Headers:");
    foreach (var header in headers)
    {
        responseText.AppendLine($"  {header.Key}: {header.Value}");
    }
    responseText.AppendLine("</pre>");

    await context.Response.WriteAsync(responseText.ToString());
});

app.Run(url);
