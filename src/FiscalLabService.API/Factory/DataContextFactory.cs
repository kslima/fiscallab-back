using FiscalLabService.Repository.PostgreSql.Context;
using FiscalLabService.Repository.PostgreSql.Resources;
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

        var postgresOptions = configuration
            .GetSection(nameof(PostgresOptions))
                                .Get<PostgresOptions>()!;
        
        var seedDataOptions = configuration
            .GetSection(nameof(SeedDataOptions))
            .Get<SeedDataOptions>()!;
        
        var builder = new DbContextOptionsBuilder<ApplicationContext>()
            .UseNpgsql(postgresOptions.ConnectionString);
        
        return new ApplicationContext(builder.Options, seedDataOptions);
    }
}