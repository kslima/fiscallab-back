using FiscalLabService.Domain.Enums;

namespace FiscalLabService.App.Dtos.Shared;

public class SystemConsistencyDto
{
    public string Oc { get; set; } = string.Empty;
    public string Farm { get; set; } = string.Empty;
    public string Owner { get; set; } = string.Empty;
    public Clarify? Clarifier { get; set; }
    public SugarcaneAnalysisDto PlantSugarcaneAnalysis { get; set; } = null!; 
    public SugarcaneAnalysisDto ConsecanaSugarcaneAnalysis { get; set; } = null!; 
    public decimal DifferencePurity { get; set; }
    public decimal DifferencePol { get; set; }
    public decimal DifferenceFiber { get; set; }
    public decimal DifferencePcc { get; set; }
    public decimal DifferenceAr { get; set; }
    public decimal DifferenceAtr { get; set; }
    public string Observations { get; set; } = string.Empty;
}