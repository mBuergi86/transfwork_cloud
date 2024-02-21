using Microsoft.Extensions.Options;
using MongoDB.Driver;
using todoApi001.Models;

namespace todoApi001.Services;

public class TodoService : ITodoService
{
    private readonly IMongoCollection<Todos> _todos;
    public TodoService(IOptions<TodoStoreDatabaseSettings> todoStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            todoStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            todoStoreDatabaseSettings.Value.DatabaseName);

        _todos = mongoDatabase.GetCollection<Todos>(
            todoStoreDatabaseSettings.Value.TodosCollectionName);
    }

    public async Task<List<Todos>?> GetTodosAsync() =>
        await _todos.Find(todo => true).ToListAsync();

    public async Task<Todos?> GetTodoAsync(string id) =>
        await _todos.Find(todo => todo.Id == id).FirstOrDefaultAsync();

    public async Task<Todos> CreateTodoAsync(Todos todo)
    {
        await _todos.InsertOneAsync(todo).ConfigureAwait(false);
        return todo;
    }

    public async Task UpdateTodoAsync(string id, Todos todoUpdate) =>
        await _todos.ReplaceOneAsync(todo => todo.Id == id, todoUpdate);

    public async Task DeleteTodoAsync(string id) =>
        await _todos.DeleteOneAsync(todo => todo.Id == id);
}
