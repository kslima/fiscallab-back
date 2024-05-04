using FiscalLabService.Shared.Extensions;
using FluentValidation;
using FluentValidation.Validators;

namespace FiscalLabService.App.Validators;

public class OnlyNumber<T,TProperty> : PropertyValidator<T, TProperty>
{
    public override string Name => "OnlyNumberValidator";

    public override bool IsValid(ValidationContext<T> context, TProperty value)
    {
        if (value is not string) return false;

        var valueStr = value.ToString()!;
        return valueStr.IsOnlyNumber();
    }

    protected override string GetDefaultMessageTemplate(string errorCode)
        => "'{PropertyName}' must contain only number.";
}