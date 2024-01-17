using FiscalLabService.App.Dtos;
using FiscalLabService.App.Models;

namespace FiscalLabService.App.Interfaces;

public interface IPlantService
{
    Task<PlantDto> CreateAsync(PlantModel model);
    Task<PlantDto> AddEmailAsync(long plantId, AddEmailModel model);
    Task<PlantDto> RemoveEmailAsync(long plantId, string email);
    Task<List<PlantDto>> GetAllAsync();
}