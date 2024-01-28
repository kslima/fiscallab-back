namespace FiscalLabService.App.Dtos;

public class BasicInformationDto
{
    public string PlantId { get; set; } = null!;
    public PlantDto Plant { get; set; } = null!;
    public string AssociationId { get; set; } = null!;
    public AssociationDto Association { get; set; } = null!;
    public string Consultant { get; set; } = string.Empty;
    public string Inspector { get; set; } = string.Empty;
    public string Leader { get; set; } = string.Empty;
    public string LaboratoryLeader { get; set; } = string.Empty;
    public DateOnly VisitDate { get; set; }
    public TimeOnly VisitTime { get; set; }
}