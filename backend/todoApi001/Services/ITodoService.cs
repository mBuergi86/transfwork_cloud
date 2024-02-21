using todoApi001.Models;

namespace todoApi001.Services;

public interface ITodoService
{
    public Task<List<Todos>?> GetTodosAsync();
    public Task<Todos?> GetTodoAsync(string id);
    public Task<Todos> CreateTodoAsync(Todos todo);
    public Task UpdateTodoAsync(string id, Todos todoUpdate);
    public Task DeleteTodoAsync(string id);
}
