namespace FiscalLabService.App.Dtos;

public class PlantDto
{
    public long Id { get; set; } 
    public string Name { get; set; } = string.Empty;
    public List<string> Emails { get; set; } = new();
}