using FiscalLabService.Domain.Entities;

namespace FiscalLabService.Domain.ValueObjects;

public class BasicInformation
{
    public string PlantId { get; set; } = null!;
    public Plant Plant { get; set; } = null!;
    public string AssociationId { get; set; } = null!;
    public Association Association { get; set; } = null!;
    public string Consultant { get; set; } = string.Empty;
    public string Inspector { get; set; } = string.Empty;
    public string Leader { get; set; } = string.Empty;
    public string LaboratoryLeader { get; set; } = string.Empty;
    public DateOnly VisitDate { get; set; }
    public TimeOnly VisitTime { get; set; }
    public DateTime CreatedAt { get; set; }
}