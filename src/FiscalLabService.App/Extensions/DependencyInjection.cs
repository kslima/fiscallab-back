using Microsoft.Extensions.DependencyInjection;

namespace FiscalLabService.App.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddAppDependencies(this IServiceCollection services)
    {
        return services;
    }
}