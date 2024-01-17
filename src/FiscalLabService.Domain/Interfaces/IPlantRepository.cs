using FiscalLabService.Domain.Entities;

namespace FiscalLabService.Domain.Interfaces;

public interface IPlantRepository
{
    Task<Plant> CreateAsync(Plant plant);
    Task<Plant> UpdateAsync(long id, Plant plant);
    Task<Plant?> GetAsync(long id);
    Task<List<Plant>> GetAllAsync();
}