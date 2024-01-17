using FiscalLabService.Domain.Interfaces;
using FiscalLabService.Repository.SqLite.Context;
using FiscalLabService.Repository.SqLite.Repositories;
using FiscalLabService.Repository.SqLite.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace FiscalLabService.Repository.SqLite.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddSqLiteRepositoryDependencies(this IServiceCollection services)
    {
        services.AddOptionsWithValidateOnStart<SqLiteOptions>();
        services.AddDbContext<DataContext>((sp, options) =>
            options.UseSqlite(sp.GetRequiredService<IOptions<SqLiteOptions>>().Value.ConnectionString));
        
       services.AddScoped<IPlantRepository, PlantRepository>();
        return services;
    }
}