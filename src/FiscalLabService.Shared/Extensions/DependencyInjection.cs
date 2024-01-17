using Microsoft.Extensions.DependencyInjection;

namespace FiscalLabService.Shared.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddOptionsWithValidation<TOptions>(this IServiceCollection services) where TOptions : class
    {
        services
            .AddOptions<TOptions>()
            .BindConfiguration(typeof(TOptions).Name)
            .ValidateDataAnnotations()
            .ValidateOnStart();
        return services;
    }
}