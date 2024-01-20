namespace FiscalLabService.App.Dtos;

public class PlantDto
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
    public AddressDto Address { get; set; } = null!;
}