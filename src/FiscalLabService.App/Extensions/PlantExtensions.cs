using FiscalLabService.App.Dtos;
using FiscalLabService.App.Models;
using FiscalLabService.Domain.Entities;

namespace FiscalLabService.App.Extensions;

public static class PlantExtensions
{
    public static Plant AsPlant(this PlantModel model)
    {
        return new Plant
        {
            Name = model.Name,
            Emails = model.Emails
                .Select(e => e.AsPlantEmail())
                .ToList()
        };
    }
    
    public static PlantDto AsPlantDto(this Plant plant)
    {
        return new PlantDto
        {
            Id = plant.Id,
            Name = plant.Name,
            Emails = plant.Emails
                .Select(e => e.Address)
                .ToList()
        };
    }
    
    private static PlantEmail AsPlantEmail(this string email)
    {
        return new PlantEmail
        {
            Address = email
        };
    }
}