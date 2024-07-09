using FiscalLabService.App.Dtos;
using FiscalLabService.App.Dtos.Shared;
using FiscalLabService.Domain.ValueObjects;

namespace FiscalLabService.App.Extensions;

public static class AddressExtensions
{
    public static Address AsAddress(this AddressDto addressDto)
    {
        return new Address
        {
            City = addressDto.City,
            State = addressDto.State
        };
    }
    
    public static AddressDto AsAddressDto(this Address address)
    {
        return new AddressDto
        {
            City = address.City,
            State = address.State
        };
    }
}