namespace TodoApi.Models
{
    public class TodoStoreDatabaseSettings : ITodoStoreDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!; 
        public string TodosCollectionName { get; set; } = null!;
    }
}
