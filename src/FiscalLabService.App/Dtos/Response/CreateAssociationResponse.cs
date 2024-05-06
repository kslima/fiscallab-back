namespace FiscalLabService.App.Dtos.Response;

public class CreateAssociationResponse
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public AddressDto Address { get; set; } = null!;
    public List<EmailDto> Emails { get; set; } = null!;
}