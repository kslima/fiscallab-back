using FiscalLabService.App.Dtos;
using FiscalLabService.App.Models;

namespace FiscalLabService.App.Interfaces;

public interface IPlantService
{
    Task<UpsertPlantDto> UpsertPlantAsync(UpsertPlantsModel model);
}