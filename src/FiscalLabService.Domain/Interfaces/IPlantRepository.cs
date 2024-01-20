using FiscalLabService.Domain.Entities;

namespace FiscalLabService.Domain.Interfaces;

public interface IPlantRepository
{
    Task<List<Plant>> CreateManyAsync(List<Plant> plants);
    Task<List<Plant>> UpdateManyAsync(List<Plant> plants);
    Task<List<Plant>> GetByIdsAsync(List<string> ids);
    Task<List<Plant>> GetAllAsync();
}