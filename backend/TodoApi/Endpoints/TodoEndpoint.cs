using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Endpoints;

public static class TodoEndpoint
{
    public static RouteGroupBuilder MapTodos(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/todos");

        group.MapGet("/", async (ITodoService service) =>
        {
            return await service.GetTodosAsync();
        });

        group.MapGet("/{id}", async (ITodoService service, string id) =>
        {
            var todo = await service.GetTodoAsync(id);

            if (todo is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(todo);
        });

        group.MapPost("/", async (ITodoService service, Todos todo) =>
        {
            await service.CreateTodoAsync(todo);

            return Results.Created($"/todos/{todo.Id}", todo);
        });

        group.MapPut("/{id}", async (ITodoService service, string id, Todos todo) =>
        {
            await service.UpdateTodoAsync(id, todo);
            return Results.NoContent();
        });

        group.MapDelete("/{id}", async (ITodoService service, string id) =>
        {
            await service.DeleteTodoAsync(id);
            return Results.NoContent();
        });

        return group;
    }   
}
