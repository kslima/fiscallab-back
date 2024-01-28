using FiscalLabService.App.Dtos;
using FiscalLabService.App.Extensions;
using FiscalLabService.App.Interfaces;
using FiscalLabService.App.Models;
using FiscalLabService.Domain.Entities;
using FiscalLabService.Domain.Interfaces;
using FiscalLabService.Shared.Responses;

namespace FiscalLabService.App.Services;

public class PlantService : IPlantService
{
    private readonly IPlantRepository _plantRepository;

    public PlantService(IPlantRepository plantRepository)
    {
        _plantRepository = plantRepository;
    }

    public async Task<Result<UpsertPlantsDto>> UpsertAsync(UpsertPlantsModel model)
    {
        var toUpsertPlantIds = model.Plants.Select(p => p.Id).ToList();
        var existingPlants = await _plantRepository.GetByIdsAsync(toUpsertPlantIds);

        var toUpdatePlants = new List<Plant>();
        var toInsertPlants = new List<Plant>();
        
        foreach (var modelPlant in model.Plants)
        {
            var toUpsertPlant = existingPlants.Find(p => p.Id.Equals(modelPlant.Id));
            if (toUpsertPlant is null)
            {
                toInsertPlants.Add(modelPlant.AsPlant());
                continue;
            }
            
            toUpdatePlants.Add(modelPlant.AsPlant());
        }
        
        var updatedPlants = await _plantRepository.UpdateManyAsync(toUpdatePlants);
        var insertedPlants = await _plantRepository.CreateManyAsync(toInsertPlants);
        
        var allPlants = insertedPlants
            .Concat(updatedPlants)
            .Select(p => p.AsPlantDto())
            .ToList();

        var dto = new UpsertPlantsDto { Plants = allPlants };
        return Result<UpsertPlantsDto>.Success(dto);
    }

    public async Task<Result<List<PlantDto>>> GetAllAsync()
    {
        var plants = await _plantRepository.ListAsync();

        var plantsDto = plants.Select(p => p.AsPlantDto()).ToList();
        return Result<List<PlantDto>>
            .Success(plantsDto);
    }
}