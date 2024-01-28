using System.Diagnostics.CodeAnalysis;

namespace FiscalLabService.Shared.Exceptions;
using System.Runtime.Serialization;

[Serializable]
public class EnvironmentVariableNotFoundException : Exception
{
    public EnvironmentVariableNotFoundException()
    {
    }

    protected EnvironmentVariableNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public EnvironmentVariableNotFoundException(string? message) : base(message)
    {
    }

    public EnvironmentVariableNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    public static void ThrowIfNull(
        [NotNull] object? argument,
        string variableName)
    {
        if (argument is null)
        {
            throw new EnvironmentVariableNotFoundException($"'{variableName}' environment variable not found");
        }
    }
}