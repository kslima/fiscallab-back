namespace FiscalLabService.App.Models;

public class EmailAttachmentModel
{
    public byte[] Content { get; set; } = [];
    public string Name { get; set; } = string.Empty;
    public string MediaType { get; set; } = "application/pdf";
}