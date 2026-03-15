using Kumi.Domain.Tools;
using Microsoft.EntityFrameworkCore;

namespace Kumi.Persistence;

public class KumiDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=8973;Database=kumi;Username=kumi;Password=KumiDb123");
        base.OnConfiguring(optionsBuilder);
    }
}
