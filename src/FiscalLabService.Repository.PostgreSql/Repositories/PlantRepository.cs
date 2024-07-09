using System.Linq.Expressions;
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

    public async Task<Plant> CreateAsync(Plant plant)
    {
        await _context.Plants.AddAsync(plant);
        await _context.SaveChangesAsync();
        return plant;
    }
    
    public Task<bool> ExistsAsync(Expression<Func<Plant,bool>> predicate)
    {
        return _context.Plants
            .AnyAsync(predicate);
    }

    public async Task<List<Plant>> CreateManyAsync(List<Plant> plants)
    {
        await _context.Plants.AddRangeAsync(plants);
        await _context.SaveChangesAsync();
        return plants;
    }

    public async Task<Plant> UpdateAsync(string id, Plant plant)
    {
        var plantToUpdate = await _context.Plants
            .AsNoTracking()
            .Where(p => p.Id.Equals(id))
            .SingleAsync();
        
        plantToUpdate.Name = plant.Name;
        plantToUpdate.Cnpj = plant.Cnpj;
        plantToUpdate.Address.City = plant.Address.City;
        plantToUpdate.Address.State = plant.Address.State;
        
        _context.Plants.Update(plantToUpdate);
        await _context.SaveChangesAsync();
        return plantToUpdate;
    }
    public async Task<List<Plant>> UpdateManyAsync(List<Plant> plants)
    {
        var plantIds = plants.Select(p => p.Id);

        var plantsToUpdate = _context.Plants
            .AsNoTracking()
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

    public async Task<Plant?> GetByIdAsync(string id)
    {
        return await _context.Plants
            .AsNoTracking()
            .Where(p => id.Contains(p.Id))
            .FirstOrDefaultAsync();
    }
    
    public async Task<int> DeleteAsync(string id)
    {
        var plant = await _context.Plants
            .SingleAsync(x => x.Id.Equals(id));
        _context.Plants.Remove(plant);
        return await _context.SaveChangesAsync();
    }
    
    public async Task<List<Plant>> GetByIdsAsync(List<string> ids)
    {
        return await _context.Plants
          
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