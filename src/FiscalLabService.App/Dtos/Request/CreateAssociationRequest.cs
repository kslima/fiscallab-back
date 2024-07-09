using FiscalLabService.App.Dtos.Shared;

namespace FiscalLabService.App.Dtos.Request;

public class CreateAssociationRequest
{
    public string Name { get; set; } = string.Empty;
    public AddressDto Address { get; set; } = null!;
    public List<EmailDto> Emails { get; set; } = null!;
}