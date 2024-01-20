using FiscalLabService.Domain.ValueObjects;

namespace FiscalLabService.Domain.Entities;

public class Menu
{
    public string Id { get; set; } = string.Empty;
    public string Page { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public List<Option> Options { get; set; } = [];
}