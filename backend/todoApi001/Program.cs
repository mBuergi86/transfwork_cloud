using todoApi001.Endpoints;
using todoApi001.Models;
using todoApi001.Services;

var builder = WebApplication.CreateBuilder(args);

// Zuerst konfiguriere und registriere die ITodoStoreDatabaseSettings-Abh�ngigkeit
builder.Services.Configure<TodoStoreDatabaseSettings>(
    builder.Configuration.GetSection("TodoStoreDatabase"));

// F�ge den TodoService als Singleton-Dienst hinzu
builder.Services.AddSingleton<ITodoService, TodoService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder
           .AllowAnyMethod()
                  .AllowAnyHeader()
                         .SetIsOriginAllowed((host) => true)
                                .AllowCredentials());
});

var app = builder.Build();

app.MapTodos();

app.UseCors("CorsPolicy");
app.MapGet("/", () => "Hello World!");

app.Run();
