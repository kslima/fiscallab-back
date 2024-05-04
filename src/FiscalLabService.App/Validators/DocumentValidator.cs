using FiscalLabService.App.Extensions;
using FluentValidation;
using FluentValidation.Validators;

namespace FiscalLabService.App.Validators;

public class DocumentValidator<T,TProperty> : PropertyValidator<T, TProperty>
{
    public override string Name => "CpnjValidator";

    public override bool IsValid(ValidationContext<T> context, TProperty value)
    {
        var document = value as string ?? string.Empty;
        return document.IsValidCnpj();
    }

    protected override string GetDefaultMessageTemplate(string errorCode)
        => "'{PropertyName}' has an invalid format.";
}