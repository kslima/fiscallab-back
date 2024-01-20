namespace FiscalLabService.App.Dtos;

public class MenuDto
{
    public string Id { get; set; } = string.Empty;
    public string Page { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public List<OptionDto> Options { get; set; } = [];
}