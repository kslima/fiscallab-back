using FiscalLabService.Domain.Interfaces;
using FiscalLabService.Repository.PostgreSql.Context;
using FiscalLabService.Repository.PostgreSql.Repositories;
using FiscalLabService.Repository.PostgreSql.Resources;
using FiscalLabService.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FiscalLabService.Repository.PostgreSql.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddSqLiteRepositoryDependencies(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var postgresOptions = LoadPostgresOptions(configuration);
        services.AddDbContext<ApplicationContext>(options =>
            options.UseNpgsql(postgresOptions.ConnectionString,
                    builder => { builder.EnableRetryOnFailure(2, TimeSpan.FromSeconds(5), null); })
                .EnableSensitiveDataLogging()
        );

        var seedDataOptions = configuration
            .GetRequiredSection(nameof(SeedDataOptions))
            .Get<SeedDataOptions>()!;

        services.AddSingleton(seedDataOptions);
        
        services.AddScoped<IPlantRepository, PlantRepository>();
        services.AddScoped<IAssociationRepository, AssociationRepository>();
        services.AddScoped<IMenuRepository, MenuRepository>();
        services.AddScoped<IVisitPageRepository, VisitPageRepository>();
        return services;
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