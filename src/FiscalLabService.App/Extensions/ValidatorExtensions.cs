using FiscalLabService.App.Validators;
using FluentValidation;

namespace FiscalLabService.App.Extensions;

public static class ValidatorExtensions
{
    public static IRuleBuilderOptions<T, TProperty> ValidDocument<T, TProperty>(
        this IRuleBuilder<T, TProperty> ruleBuilder)
    {
        return ruleBuilder.SetValidator(new DocumentValidator<T, TProperty>());
    }

    public static IRuleBuilderOptions<T, TProperty> OnlyNumber<T, TProperty>(
        this IRuleBuilder<T, TProperty> ruleBuilder)
        => ruleBuilder.SetValidator(new OnlyNumber<T, TProperty>());

    
    public static bool IsValidCnpj(this string value)
    {
        var multiplier1 = new[] {5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2};
        var multiplier2 = new[] {6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2};

        value = value.Trim();
        value = value.Replace(".", "")
            .Replace("-", "")
            .Replace("/", "");

        if (value.Length != 14)
            return false;

        var tempCnpj = value[..12];
        var sum = 0;
            
        for (var i = 0; i < 12; i++)
            sum += int.Parse(tempCnpj[i].ToString()) * multiplier1[i];
            
        var rest = (sum % 11);
        if (rest < 2)
            rest = 0;
        else
            rest = 11 - rest;
        var digit = rest.ToString();
        tempCnpj += digit;
        sum = 0;
            
        for (var i = 0; i < 13; i++)
            sum += int.Parse(tempCnpj[i].ToString()) * multiplier2[i];
        rest = sum % 11;
        if (rest < 2)
            rest = 0;
        else
            rest = 11 - rest;
        digit += rest.ToString();
        return value.EndsWith(digit);
    }
}