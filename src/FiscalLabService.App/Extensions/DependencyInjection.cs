using FiscalLabService.App.Interfaces;
using FiscalLabService.App.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FiscalLabService.App.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddAppDependencies(this IServiceCollection services)
    {
        services.AddScoped<IPlantService, PlantService>();
        services.AddScoped<IAssociationService, AssociationService>();
        return services;
    }
}