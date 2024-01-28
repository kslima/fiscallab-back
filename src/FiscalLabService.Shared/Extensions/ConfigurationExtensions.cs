using FiscalLabService.Shared.Exceptions;
using Microsoft.Extensions.Configuration;

namespace FiscalLabService.Shared.Extensions;

public static class ConfigurationExtensions
{
    public static T GetRequiredValue<T>(this IConfiguration configuration, string variableName)
    {
        var variableValue = configuration.GetValue<T>(variableName);
        EnvironmentVariableNotFoundException.ThrowIfNull(variableValue, variableName);

        return variableValue;
    }
}