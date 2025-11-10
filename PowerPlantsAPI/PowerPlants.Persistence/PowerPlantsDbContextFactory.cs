using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PowerPlants.Persistence;

public class PowerPlantsDbContextFactory : IDesignTimeDbContextFactory<PowerPlantsDbContext>
{
    public PowerPlantsDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<PowerPlantsDbContext>();

        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=PowerPlantsDb;User Id=sa;Password=PowerPlants!StrongPassword123;TrustServerCertificate=True;Encrypt=False;");

        return new PowerPlantsDbContext(optionsBuilder.Options);
    }
}