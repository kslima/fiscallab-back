using FiscalLabService.Repository.PostgreSql.Context;
using FiscalLabService.Repository.PostgreSql.Resources;
using FiscalLabService.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FiscalLabService.API.Factory;

public class DataContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
{
    public ApplicationContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false)
            .AddUserSecrets<Program>()
            .Build();

        var postgresOptions = LoadPostgresOptions(configuration);

        var seedDataOptions = configuration
            .GetSection(nameof(SeedDataOptions))
            .Get<SeedDataOptions>()!;

        var builder = new DbContextOptionsBuilder<ApplicationContext>()
            .UseNpgsql(postgresOptions.ConnectionString);

        return new ApplicationContext(builder.Options, seedDataOptions);
    }
    
    private static PostgresOptions LoadPostgresOptions(IConfiguration configuration)
    {
        var postgresOptions = configuration
            .GetSection(nameof(PostgresOptions))
            .Get<PostgresOptions>() ?? new PostgresOptions();

        postgresOptions.Host = configuration.GetRequiredValue<string>("POSTGRES_HOST");
        postgresOptions.Port = configuration.GetRequiredValue<string>("POSTGRES_PORT");
        postgresOptions.User = configuration.GetRequiredValue<string>("POSTGRES_USER");
        postgresOptions.Password = configuration.GetRequiredValue<string>("POSTGRES_PASSWORD");
        postgresOptions.Database = configuration.GetRequiredValue<string>("POSTGRES_DB");

        return postgresOptions;
    }
}