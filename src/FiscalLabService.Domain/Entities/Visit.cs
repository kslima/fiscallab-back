using FiscalLabService.Domain.ValueObjects;

namespace FiscalLabService.Domain.Entities;

public class Visit
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public BasicInformation BasicInformation { get; set; } = null!;
    public SugarcaneBalance SugarcaneBalance { get; set; } = null!;
    public DesintegratorProbe DesintegratorProbe { get; set; } = null!;
    public AnalyticalBalance AnalyticalBalance { get; set; } = null!;
    public PressRefractometer PressRefractometer { get; set; } = null!;
    public ClarificationSaccharimeter ClarificationSaccharimeter { get; set; } = null!;
    public BenchmarkingEquipment BenchmarkingEquipment { get; set; } = null!;
    public SystemConsistency SystemConsistency { get; set; } = null!;
    public Conclusion Conclusion { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public List<Image> Images { get; set; } = [];
}