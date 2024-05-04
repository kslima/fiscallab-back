using System.Linq.Expressions;
using FiscalLabService.Domain.Entities;

namespace FiscalLabService.Domain.Interfaces;

public interface IPlantRepository
{
    Task<Plant> CreateAsync(Plant plant);
    Task<bool> ExistsAsync(Expression<Func<Plant, bool>> predicate);
    Task<List<Plant>> CreateManyAsync(List<Plant> plants);
    Task<Plant> UpdateAsync(string id, Plant plant);
    Task<List<Plant>> UpdateManyAsync(List<Plant> plants);
    Task<Plant?> GetByIdAsync(string id);
    Task<List<Plant>> GetByIdsAsync(List<string> ids);
    Task<List<Plant>> ListAsync();
}