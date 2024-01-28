using FiscalLabService.Domain.Entities;
using FiscalLabService.Domain.Interfaces;
using FiscalLabService.Repository.PostgreSql.Context;
using Microsoft.EntityFrameworkCore;

namespace FiscalLabService.Repository.PostgreSql.Repositories;

public class PlantRepository : IPlantRepository
{
    private readonly ApplicationContext _context;
    public PlantRepository(ApplicationContext context)
    {
        _context = context;
    }
    
    public async Task<List<Plant>> CreateManyAsync(List<Plant> plants)
    {
        await _context.Plants.AddRangeAsync(plants);
        await _context.SaveChangesAsync();
        return plants;
    }

    public async Task<List<Plant>> UpdateManyAsync(List<Plant> plants)
    {
        var plantIds = plants.Select(p => p.Id);

        var plantsToUpdate = _context.Plants
            .Where(p => plantIds.Contains(p.Id))
            .ToList();
        
        foreach (var plant in plantsToUpdate)
        {
            var updatedPlant = plants.First(p => p.Id.Equals(plant.Id));
            plant.Name = updatedPlant.Name;
            plant.Cnpj = updatedPlant.Cnpj;
            plant.Address = updatedPlant.Address;
        }
        
        _context.Plants.UpdateRange(plantsToUpdate);
        await _context.SaveChangesAsync();
        return plantsToUpdate;
    }

    public async Task<List<Plant>> GetByIdsAsync(List<string> ids)
    {
        return await _context.Plants
            .AsNoTracking()
            .Where(p => ids.Contains(p.Id))
            .ToListAsync();
    }

    public async Task<List<Plant>> ListAsync()
    {
        return await _context.Plants
            .AsNoTracking()
            .ToListAsync();
    }
}