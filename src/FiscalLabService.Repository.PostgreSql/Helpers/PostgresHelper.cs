using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FiscalLabService.Repository.PostgreSql.Helpers;

public static class PostgresHelper
{
    public static ValueConverter<DateTime?, DateTime?> DateTimeToUtcConverter()
    {
        return new ValueConverter<DateTime?, DateTime?>(
                src => ConvertDateToProviderExpression(src),
                dst => ConvertDateToProviderExpression(dst)
            );
    }
    
    private static DateTime? ConvertDateToProviderExpression(DateTime? date)
    {
        if (!date.HasValue) return date;

        return date.Value.Kind == DateTimeKind.Utc
            ? date
            : DateTime
                .SpecifyKind(date.Value, DateTimeKind.Local)
                .ToUniversalTime();
    }
}