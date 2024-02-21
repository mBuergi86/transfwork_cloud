using MongoDB.Bson.Serialization.Attributes;

namespace todoApi001.Models;

[BsonIgnoreExtraElements]
public class Todos
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string? Id { get; set; }
    [BsonElement("title")]
    public string? Title { get; set; }
    [BsonElement("isComplete")]
    public bool IsComplete { get; set; } = false;
}

