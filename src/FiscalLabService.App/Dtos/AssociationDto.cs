namespace FiscalLabService.App.Dtos;

public class AssociationDto
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public AddressDto Address { get; set; } = null!;
    public List<EmailDto> Emails { get; set; } = null!;
}