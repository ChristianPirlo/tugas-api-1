using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace BookStoreApi.Models;

public class PresensiHarianGuru
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Nip { get; set; }

    [BsonElement("Name")]
    [JsonPropertyName("Name")]
    public string Tgl { get; set; } = null!;

    public string Kehadiran { get; set; } = null!;
    // [Required]

    // public string? Title { get; set; }
    // public bool IsDone { get; set; }
}