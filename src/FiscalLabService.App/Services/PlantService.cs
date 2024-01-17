using FiscalLabService.App.Dtos;
using FiscalLabService.App.Extensions;
using FiscalLabService.App.Interfaces;
using FiscalLabService.App.Models;
using FiscalLabService.Domain.Entities;
using FiscalLabService.Domain.Interfaces;

namespace FiscalLabService.App.Services;

public class PlantService : IPlantService
{
    private readonly IPlantRepository _plantRepository;

    public PlantService(IPlantRepository plantRepository)
    {
        _plantRepository = plantRepository;
    }

    public async Task<PlantDto> CreateAsync(PlantModel model)
    {
        var plant = model.AsPlant();
        plant = await _plantRepository.CreateAsync(plant);
        return plant.AsPlantDto();
    }

    public async Task<PlantDto> AddEmailAsync(long plantId, AddEmailModel model)
    {
        var plant = (await _plantRepository.GetAsync(plantId))!;

        if (plant.Emails.Exists(e => e.Address.Equals(model.Email)))
        {
            return plant.AsPlantDto();
        }
        
        plant.Emails.Add(new PlantEmail{Address = model.Email});
        await _plantRepository.UpdateAsync(plantId, plant);
        return (await _plantRepository.GetAsync(plantId))!.AsPlantDto();
    }

    public async Task<PlantDto> RemoveEmailAsync(long plantId, string email)
    {
        var plant = (await _plantRepository.GetAsync(plantId))!;

        plant.Emails = plant.Emails
            .Where(e => !e.Address.Equals(email))
            .ToList();
        
        plant = await _plantRepository.UpdateAsync(plantId, plant);
        return plant.AsPlantDto();
    }

    public async Task<List<PlantDto>> GetAllAsync()
    {
        var plants = await _plantRepository
            .GetAllAsync();

        return plants
            .Select(p => p.AsPlantDto())
            .ToList();
    }
}