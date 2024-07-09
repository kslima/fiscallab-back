using FiscalLabService.App.Dtos.Shared;

namespace FiscalLabService.App.Dtos.Request;

public class CreatePlantRequest
{
    public string Name { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
    public AddressDto Address { get; set; } = null!;
}