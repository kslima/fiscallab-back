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
        services.AddScoped<IMenuService, MenuService>();
        services.AddScoped<IVisitPageService, VisitPageService>();
        services.AddScoped<IVisitService, VisitService>();
        return services;
    }
}