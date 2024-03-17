namespace FiscalLabService.App.Resources;

public class EmailTaskOptions
{
    public string CronExpression { get; set; } = string.Empty;
    public string TemplatePath { get; set; } = string.Empty;
}