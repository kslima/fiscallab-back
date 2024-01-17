using FiscalLabService.Domain.Interfaces;
using FiscalLabService.Repository.PostgreSql.Context;
using FiscalLabService.Repository.PostgreSql.Repositories;
using FiscalLabService.Repository.PostgreSql.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace FiscalLabService.Repository.PostgreSql.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddPostgresRepositoryDependencies(this IServiceCollection services)
    {
        services.AddOptionsWithValidateOnStart<PostgreSettings>();
        services.AddDbContext<DataContext>((sp, options) =>
            options.UseNpgsql("User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=fiscal-lab",
                    builder => { builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null); })
                .EnableSensitiveDataLogging()
        );
        
       services.AddScoped<IPlantRepository, PlantRepository>();
        return services;
    }
}