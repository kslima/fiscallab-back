using FiscalLabService.App.Dtos.Shared;

namespace FiscalLabService.App.Models;

public class BasicInformationModel
{
    public PlantDto Plant { get; set; } = null!;
    public AssociationDto Association { get; set; } = null!;
    public string Consultant { get; set; } = string.Empty;
    public string Inspector { get; set; } = string.Empty;
    public string Leader { get; set; } = string.Empty;
    public string LaboratoryLeader { get; set; } = string.Empty;
    public DateOnly VisitDate { get; set; }
    public TimeOnly VisitTime { get; set; }
}