using Microsoft.EntityFrameworkCore;



public class MilkContext : DbContext
{
    public MilkContext(DbContextOptions<MilkContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new DataInitializer(modelBuilder).Seed();
    }

    public DbSet<Milk> MilkProducts { get; set; } = null!;
}