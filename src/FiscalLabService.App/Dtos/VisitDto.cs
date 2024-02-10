namespace FiscalLabService.App.Dtos;

public class VisitDto
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public BasicInformationDto BasicInformation { get; set; } = null!;
    public SugarcaneBalanceDto SugarcaneBalance { get; set; } = null!;
    public DesintegratorProbeDto DesintegratorProbe { get; set; } = null!;
    public AnalyticalBalanceDto AnalyticalBalance { get; set; } = null!;
    public PressRefractometerDto PressRefractometer { get; set; } = null!;
    public ClarificationSaccharimeterDto ClarificationSaccharimeter { get; set; } = null!;
    public BenchmarkingEquipmentDto BenchmarkingEquipment { get; set; } = null!;
    public SystemConsistencyDto SystemConsistency { get; set; } = null!;
    public ConclusionDto Conclusion { get; set; } = null!;
    public bool IsFinished { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? FinishedAt { get; set; }
    public DateTime? SentAt { get; set; }
    public List<ImageDto> Images { get; set; } = [];
}