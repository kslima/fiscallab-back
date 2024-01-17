namespace FiscalLabService.Domain.Entities;

public class PlantEmail
{
    public long Id { get; set; }
    public long PlantId { get; set; }
    public string Address { get; set; } = string.Empty;
}