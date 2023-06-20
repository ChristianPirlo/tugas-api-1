using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace uas_drwa.Models;
public class presen_ngajar
{
    public string? Id { get; set; }
    public string NIP { get; set; } = null!;
    public string Tgl { get; set; } = null!;
    public string Kehadiran { get; set; } = null!;
    public string Kelas { get; set; } = null!;
}