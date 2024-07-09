namespace FiscalLabService.App.Dtos.Shared;

public class ImageDto
{
    public string Id { get; set; } = string.Empty;
    public string VisitId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public byte[] Data { get; set; } = [];
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}