namespace FiscalLabService.Repository.SqLite.Settings;

public class SqLiteOptions
{
    public string DatabaseName { get; set; } = string.Empty;
    public string ConnectionString => DatabaseName;
}