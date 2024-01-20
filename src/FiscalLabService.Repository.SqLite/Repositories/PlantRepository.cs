using FiscalLabService.Domain.Entities;
using FiscalLabService.Domain.Interfaces;
using FiscalLabService.Repository.SqLite.Context;
using Microsoft.EntityFrameworkCore;

namespace FiscalLabService.Repository.SqLite.Repositories;

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

    public async Task<Plant> UpdateAsync(string id, Plant plant)
    {
        _context.Update(plant);
        await _context.SaveChangesAsync();
        return plant;
    }

    public async Task<Plant?> GetAsync(string id)
    {
        return await _context.Plants
            .Include(p => p.Address)
            .FirstOrDefaultAsync(p => p.Id.Equals(id));
    }

    public async Task<List<Plant>> GetAllAsync()
    {
        return await _context.Plants
            .AsNoTracking()
            .Include(p => p.Address)
            .ToListAsync();
    }
}