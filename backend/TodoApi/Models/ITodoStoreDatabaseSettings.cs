namespace TodoApi.Models;

public interface ITodoStoreDatabaseSettings
{
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
    string TodosCollectionName { get; set; }
}

