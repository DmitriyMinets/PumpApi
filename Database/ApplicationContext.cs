using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database;

public class ApplicationContext : DbContext
{
    public DbSet<Pump> Pumps { get; set; } = null!;
    public DbSet<Motor> Motors { get; set; } = null!;
    public DbSet<Material> Materials { get; set; } = null!;

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Pump>(entity =>
        {
            entity.Property(e => e.Price)
                   .HasColumnType("deciaml(16, 2)");
        });

        modelBuilder.Entity<Motor>(entity =>
        {
            entity.Property(e => e.Price)
                   .HasColumnType("deciaml(16, 2)");
        });
    }
}
