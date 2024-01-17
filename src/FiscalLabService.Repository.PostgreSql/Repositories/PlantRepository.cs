using FiscalLabService.Domain.Entities;
using FiscalLabService.Domain.Interfaces;
using FiscalLabService.Repository.PostgreSql.Context;
using Microsoft.EntityFrameworkCore;

namespace FiscalLabService.Repository.PostgreSql.Repositories;

public class PlantRepository : IPlantRepository
{
    private readonly DataContext _context;

    public PlantRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Plant> CreateAsync(Plant plant)
    {
        await _context.Plants.AddAsync(plant);
        await _context.SaveChangesAsync();
        return plant;
    }

    public async Task<Plant> UpdateAsync(long id, Plant plant)
    {
        plant.Id = id;
        _context.Update(plant);
        await _context.SaveChangesAsync();
        return plant;
    }

    public async Task<Plant?> GetAsync(long id)
    {
        return await _context.Plants
            .Include(p => p.Emails)
            .FirstOrDefaultAsync(p => p.Id.Equals(id));
    }

    public async Task<List<Plant>> GetAllAsync()
    {
        return await _context.Plants
            .AsNoTracking()
            .Include(p => p.Emails)
            .ToListAsync();
    }
}