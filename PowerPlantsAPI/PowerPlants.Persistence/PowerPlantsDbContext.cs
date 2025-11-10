using Microsoft.EntityFrameworkCore;
using PowerPlants.Persistence.Entities;

namespace PowerPlants.Persistence;

public class PowerPlantsDbContext(DbContextOptions<PowerPlantsDbContext> options) : DbContext(options)
{
    public DbSet<PowerPlant> PowerPlants { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}