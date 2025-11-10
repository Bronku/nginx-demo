var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
var url = $"http://0.0.0.0:{port}";

app.MapGet("", () => "Hello World!");

app.Run(url);
