using FiscalLabService.Repository.PostgreSql.Context;
using FiscalLabService.Repository.PostgreSql.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FiscalLabService.API.Factory;

public class DataContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
{
    public ApplicationContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddUserSecrets<Program>()
            .Build();

        var postgresOptions = configuration
            .GetSection(nameof(PostgresOptions))
            .Get<PostgresOptions>()!;
        
        var builder = new DbContextOptionsBuilder<ApplicationContext>()
            .UseNpgsql(postgresOptions.ConnectionString);
        
        return new ApplicationContext(builder.Options);
    }
}