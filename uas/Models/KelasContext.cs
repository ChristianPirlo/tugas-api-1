using Microsoft.EntityFrameworkCore;

namespace Kelas.Models;

public class KelasContext : DbContext
{
    public KelasContext(DbContextOptions<KelasContext> options)
        : base(options)
    {
    }

    public DbSet<Kelas> Kelas { get; set; } = null!;
}