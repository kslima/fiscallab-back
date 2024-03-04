using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace FiscalLabService.App.Documents;

public static class DocumentExtensions
{
    private static IContainer LabelCell(this IContainer container)
    {
        var style = TextStyle.Default
            .FontSize(7)
            .Bold();

        return container
            .Border(0.3f)
            .BorderColor(Colors.Grey.Lighten1)
            .Background(Colors.Grey.Lighten2)
            .Padding(5)
            .DefaultTextStyle(style);
    }

    private static IContainer ValueCell(this IContainer container)
    {
        var style = TextStyle.Default
            .FontSize(7);

        return container
            .Border(0.3f)
            .BorderColor(Colors.Grey.Lighten1)
            .Background(Colors.White)
            .Padding(5)
            .DefaultTextStyle(style);
    }

    private static IContainer NumberValueCell(this IContainer container, decimal value)
    {
        var style = TextStyle.Default
            .FontSize(7);

        if (value < 0)
        {
            style = style.FontColor(Colors.Red.Lighten1);
        }

        return container
            .Border(0.3f)
            .BorderColor(Colors.Grey.Lighten1)
            .Background(Colors.White)
            .Padding(5)
            .DefaultTextStyle(style);
    }
    
    private static IContainer NumberValueCell(this IContainer container, float value)
    {
        return NumberValueCell(container, (decimal) value);
    }

    private static IContainer TitleCell(this IContainer container)
    {
        var titleStyle = TextStyle.Default
            .FontSize(9)
            .Bold()
            .FontColor(Colors.White);

        return container
            .Border(0.3f)
            .BorderColor(Colors.Grey.Lighten1)
            .Background(DocumentConstants.CellTitleColor)
            .Padding(5)
            .DefaultTextStyle(titleStyle);
    }
    
    private static IContainer SubLabelCell(this IContainer container)
    {
        var style = TextStyle.Default
            .FontSize(7)
            .Bold();

        return container
            .Border(0.3f)
            .BorderColor(Colors.Grey.Lighten1)
            .Background(Colors.Grey.Lighten4)
            .Padding(5)
            .DefaultTextStyle(style);
    }

    public static void SubLabelCell(this IContainer container, string text) => container.SubLabelCell().Text(text.GetValueOrDefault()).Medium();
    
    public static void LabelTitleCell(this IContainer container, string text) => container.TitleCell()
        .Text(text.GetValueOrDefault()).Bold();

    public static void LabelCell(this IContainer container, string text) => container.LabelCell().Text(text.GetValueOrDefault()).Medium();

    public static IContainer ValueCell(this IContainer container, string tex)
    {
        container.ValueCell().Text(tex.GetValueOrDefault());
        return container;
    }

    private static string GetValueOrDefault(this string value)
    {
        return string.IsNullOrWhiteSpace(value) ? "-" : value;
    }
    
    public static IContainer DecimalValueCell(this IContainer container, decimal value)
    {
        container.NumberValueCell(value).Text(value.ToString("n", System.Globalization.CultureInfo.GetCultureInfo("pt-BR")));
        return container;
    }
    
    public static IContainer DecimalValueCell(this IContainer container, float value)
    {
        container.NumberValueCell(value).Text(value.ToString("n", System.Globalization.CultureInfo.GetCultureInfo("pt-BR")));
        return container;
    }
}