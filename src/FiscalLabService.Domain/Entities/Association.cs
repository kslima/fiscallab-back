using FiscalLabService.Domain.ValueObjects;

namespace FiscalLabService.Domain.Entities;

public class Association
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public List<Email> Emails { get; set; } = [];
    public Address Address { get; set; } = null!;
}