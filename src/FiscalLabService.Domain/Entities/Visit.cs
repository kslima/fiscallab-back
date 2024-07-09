using FiscalLabService.Domain.Enums;
using FiscalLabService.Domain.ValueObjects;

namespace FiscalLabService.Domain.Entities;

public class Visit
{
    public string Id { get; set; } = string.Empty;
    public VisitStatus Status { get; set; } = VisitStatus.InProgress;
    public BasicInformation BasicInformation { get; set; } = null!;
    public SugarcaneBalance SugarcaneBalance { get; set; } = null!;
    public DesintegratorProbe DesintegratorProbe { get; set; } = null!;
    public AnalyticalBalance AnalyticalBalance { get; set; } = null!;
    public PressRefractometer PressRefractometer { get; set; } = null!;
    public ClarificationSaccharimeter ClarificationSaccharimeter { get; set; } = null!;
    public BenchmarkingEquipment BenchmarkingEquipment { get; set; } = null!;
    public SystemConsistency SystemConsistency { get; set; } = null!;
    public Conclusion Conclusion { get; set; } = null!;
    public bool NotifyByEmail { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? FinishedAt { get; set; }
    public DateTime? SyncedAt { get; set; }
    public DateTime? NotifiedByEmailAt { get; set; }
    public List<BalanceTest> BalanceTests { get; set; } = [];
}