using FiscalLabService.Domain.Entities;

namespace FiscalLabService.Domain.Interfaces;

public interface IPlantRepository
{
    Task<Plant> CreateAsync(Plant plant);
    Task<Plant> UpdateAsync(string id, Plant plant);
    Task<Plant?> GetAsync(string id);
    Task<List<Plant>> GetAllAsync();
}