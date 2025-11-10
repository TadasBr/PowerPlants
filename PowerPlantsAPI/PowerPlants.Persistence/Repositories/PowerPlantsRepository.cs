using Microsoft.EntityFrameworkCore;
using PowerPlants.Persistence.Entities;

namespace PowerPlants.Persistence.Repositories
{
    public class PowerPlantsRepository(PowerPlantsDbContext context) : IPowerPlantsRepository
    {
        private readonly PowerPlantsDbContext _context = context;

        public async Task<List<PowerPlant>> GetAllAsync(string? ownerFilter = null)
        {
            IQueryable<PowerPlant> query = _context.PowerPlants;

            if (!string.IsNullOrWhiteSpace(ownerFilter))
            {
                query = query.Where(p => EF.Functions.Collate(p.Owner, "Latin1_General_CI_AI").Contains(ownerFilter));
            }

            return await query.ToListAsync();
        }

        public async Task<PowerPlant?> GetByIdAsync(int id)
        {
            return await _context.PowerPlants.FindAsync(id);
        }

        public async Task AddAsync(PowerPlant powerPlant)
        {
            await _context.PowerPlants.AddAsync(powerPlant);
            await _context.SaveChangesAsync();
        }
    }
}