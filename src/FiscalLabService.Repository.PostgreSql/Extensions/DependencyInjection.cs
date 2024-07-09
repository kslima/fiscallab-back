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
    public static IServiceCollection AddPostgresRepositoryDependencies(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var visitOptions = LoadVisitOptions(configuration);
        services.AddSingleton(visitOptions);
        
        var postgresOptions = LoadPostgresOptions(configuration);
        services.AddDbContext<ApplicationContext>(options =>
            options.UseNpgsql(postgresOptions.ConnectionString)
                .EnableSensitiveDataLogging()
        );
        services.AddSingleton(postgresOptions);
        
        var seedDataOptions = configuration
            .GetRequiredSection(nameof(SeedDataOptions))
            .Get<SeedDataOptions>()!;

        services.AddSingleton(seedDataOptions);
        
        services.AddScoped<IPlantRepository, PlantRepository>();
        services.AddScoped<IAssociationRepository, AssociationRepository>();
        services.AddScoped<IMenuRepository, MenuRepository>();
        services.AddScoped<IVisitPageRepository, VisitPageRepository>();
        services.AddScoped<IVisitRepository, VisitRepository>();
        services.AddScoped<IImageRepository, ImageRepository>();
        
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
    
    private static VisitOptions LoadVisitOptions(IConfiguration configuration)
    {
        var visitOptions = configuration
            .GetSection(nameof(VisitOptions))
            .Get<VisitOptions>() ?? new VisitOptions();

        visitOptions.DefaultPageSize = configuration.GetRequiredValue<int>("DEFAULT_VISIT_PAGE_SIZE");
        return visitOptions;
    }
}