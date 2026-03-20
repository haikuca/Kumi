using Kumi.Domain.Tools;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Kumi.Persistence;

public class KumiDbContext : DbContext
{

    public DbSet<Tool> Tools { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var dataSourceBuilder = new NpgsqlDataSourceBuilder(
            "Host=localhost;Port=8973;Database=kumi;Username=kumi;Password=KumiDb123"
        );

        dataSourceBuilder.EnableDynamicJson();

        var dataSource = dataSourceBuilder.Build();

        optionsBuilder.UseNpgsql(dataSource);
    }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tool>()
            .Property(x => x.Parameters)
            .HasColumnType("jsonb");
            
        base.OnModelCreating(modelBuilder);
    }

}
