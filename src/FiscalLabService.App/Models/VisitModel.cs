namespace FiscalLabService.App.Models;

public class VisitModel
{
    public string Id { get; set; } = string.Empty;
    public BasicInformationModel BasicInformation { get; set; } = null!;
    public SugarcaneBalanceModel SugarcaneBalance { get; set; } = null!;
    public DesintegratorProbeModel DesintegratorProbe { get; set; } = null!;
    public AnalyticalBalanceModel AnalyticalBalance { get; set; } = null!;
    public PressRefractometerModel PressRefractometer { get; set; } = null!;
    public ClarificationSaccharimeterModel ClarificationSaccharimeter { get; set; } = null!;
    public BenchmarkingEquipmentModel BenchmarkingEquipment { get; set; } = null!;
    public SystemConsistencyModel SystemConsistency { get; set; } = null!;
    public ConclusionModel Conclusion { get; set; } = null!;
    public bool IsFinished { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime FinishedAt { get; set; }
    public DateTime? SentAt { get; set; }
    public List<ImageModel> Images { get; set; } = [];
}