using FiscalLabService.App.Dtos;
using FiscalLabService.App.Dtos.Request;
using FiscalLabService.App.Dtos.Response;
using FiscalLabService.App.Dtos.Shared;
using FiscalLabService.Domain.Entities;
using FiscalLabService.Domain.ValueObjects;

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

    public static Plant AsPlant(this CreatePlantRequest request)
    {
        return new Plant
        {
            Id = Guid.NewGuid().ToString(),
            Name = request.Name,
            Cnpj = request.Cnpj,
            Address = new Address
            {
                City = request.Address.City,
                State = request.Address.State
            }
        };
    }
    
    public static CreatePlantResponse AsCreatePlantResponse(this Plant plant)
    {
        return new CreatePlantResponse
        {
            Id = plant.Id,
            Name = plant.Name,
            Cnpj = plant.Cnpj,
            Address = new AddressDto
            {
                City = plant.Address.City,
                State = plant.Address.State
            }
        };
    }
}