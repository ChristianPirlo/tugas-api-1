using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace uas_drwa.Models;

public class Mapel
{

    public string? Id { get; set; }
    public string? Nama { get; set; }
    public string? Kelas { get; set; }
}