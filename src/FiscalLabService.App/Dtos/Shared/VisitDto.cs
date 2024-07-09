using FiscalLabService.Domain.Enums;

namespace FiscalLabService.App.Dtos.Shared;

public class VisitDto
{
    public string Id { get; set; } = string.Empty;
    public VisitStatus? Status { get; set; }
    public BasicInformationDto BasicInformation { get; set; } = null!;
    public SugarcaneBalanceDto SugarcaneBalance { get; set; } = null!;
    public DesintegratorProbeDto DesintegratorProbe { get; set; } = null!;
    public AnalyticalBalanceDto AnalyticalBalance { get; set; } = null!;
    public PressRefractometerDto PressRefractometer { get; set; } = null!;
    public ClarificationSaccharimeterDto ClarificationSaccharimeter { get; set; } = null!;
    public BenchmarkingEquipmentDto BenchmarkingEquipment { get; set; } = null!;
    public SystemConsistencyDto SystemConsistency { get; set; } = null!;
    public ConclusionDto Conclusion { get; set; } = null!;
    public bool NotifyByEmail { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? FinishedAt { get; set; }
    public DateTime? NotifiedByEmailAt { get; set; }
    public List<BalanceTestDto> BalanceTests { get; set; } = [];
}