using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace uas_drwa.Models;
public class guru
{
    public string? Id { get; set; }
    public string? Nama { get; set; }
    public string? Kelas { get; set; }
    public decimal? NIP { get; set; }
}