namespace FiscalLabService.App.Models;

public class EmailModel
{
    public string[] Recipients { get; set; } = [];
    public string[] Cc { get; set; } = [];
    public string Subject { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public EmailAttachmentModel? Attachment { get; set; }
}