using FiscalLabService.App.Dtos;
using FiscalLabService.Domain.Entities;

namespace FiscalLabService.App.Extensions;

public static class PlantExtensions
{
    public static Plant AsPlant(this PlantDto plantDto)
    {
        return new Plant
        {
            Id = plantDto.Id,
            Name = plantDto.Name,
            Cnpj = plantDto.Cnpj,
            Address = plantDto.Address.AsAddress()
        };
    }
    
    public static PlantDto AsPlantDto(this Plant plant)
    {
        return new PlantDto
        {
            Id = plant.Id,
            Name = plant.Name,
            Cnpj = plant.Cnpj,
            Address = plant.Address.AsAddressDto()
        };
    }
}