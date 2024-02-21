using TodoApi.Endpoints;
using TodoApi.Models;
using TodoApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Zuerst konfiguriere und registriere die ITodoStoreDatabaseSettings-Abhängigkeit
builder.Services.Configure<TodoStoreDatabaseSettings>(
    builder.Configuration.GetSection("TodoStoreDatabase"));

// Füge den TodoService als Singleton-Dienst hinzu
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

app.Run();

