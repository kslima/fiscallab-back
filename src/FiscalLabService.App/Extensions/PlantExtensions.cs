using FiscalLabService.App.Dtos;
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
    
    private static Address AsAddress(this AddressDto addressDto)
    {
        return new Address
        {
            City = addressDto.City,
            State = addressDto.State
        };
    }
    
    private static AddressDto AsAddressDto(this Address address)
    {
        return new AddressDto
        {
            City = address.City,
            State = address.State
        };
    }
}