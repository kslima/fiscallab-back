namespace FiscalLabService.App.Resources;

public class ValidationMessageOptions
{
    public string PlantNotFoundCode { get; set; } = string.Empty;
    public string PlantNotFoundMessage { get; set; } = string.Empty;
    public string DuplicatedPlantCode { get; set; } = string.Empty;
    public string DuplicatedPlantMessage { get; set; } = string.Empty;
    
    public string AssociationNotFoundCode { get; set; } = string.Empty;
    public string AssociationNotFoundMessage { get; set; } = string.Empty;
    public string DuplicatedAssociationCode { get; set; } = string.Empty;
    public string DuplicatedAssociationMessage { get; set; } = string.Empty;
}