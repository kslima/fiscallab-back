using FiscalLabService.App.Dtos;
using FiscalLabService.App.Models;
using FiscalLabService.Shared.Responses;

namespace FiscalLabService.App.Interfaces;

public interface IPlantService
{
    Task<Result<UpsertPlantDto>> UpsertAsync(UpsertPlantsModel model);
    Task<Result<List<PlantDto>>> GetAllAsync();
}