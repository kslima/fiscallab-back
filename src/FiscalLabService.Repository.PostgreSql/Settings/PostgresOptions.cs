namespace FiscalLabService.Repository.PostgreSql.Settings;

public class PostgresOptions
{
    public string Host { get; set; } = string.Empty;
    public string Port { get; set; } = string.Empty;
    public string Database { get; set; } = string.Empty;
    public string User { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    
    public string ConnectionString => $"User ID={User};Password={Password};Host={Host};Port={Port};Database={Database}";
}