namespace FiscalLabService.App.Models;

public class BasicInformationModel
{
    public string PlantId { get; set; } = null!;
    public string AssociationId { get; set; } = null!;
    public string Consultant { get; set; } = string.Empty;
    public string Inspector { get; set; } = string.Empty;
    public string Leader { get; set; } = string.Empty;
    public string LaboratoryLeader { get; set; } = string.Empty;
    public DateOnly VisitDate { get; set; }
    public TimeOnly VisitTime { get; set; }
}