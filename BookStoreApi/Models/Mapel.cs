using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace BookStoreApi.Models;

public class Mapel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    [JsonPropertyName("Name")]
    public string Nama { get; set; } = null!;

    public string Kelas { get; set; } = null!;
    // [Required]

    // public string? Title { get; set; }
    // public bool IsDone { get; set; }
}