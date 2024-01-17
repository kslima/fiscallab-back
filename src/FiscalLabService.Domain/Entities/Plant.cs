namespace FiscalLabService.Domain.Entities;

public class Plant
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<PlantEmail> Emails { get; set; } = new();
}