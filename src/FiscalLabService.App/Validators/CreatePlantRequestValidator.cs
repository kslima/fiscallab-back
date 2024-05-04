using FiscalLabService.App.Dtos.Request;
using FluentValidation;

namespace FiscalLabService.App.Validators;

public class CreatePlantRequestValidator : AbstractValidator<CreatePlantRequest>
{
    public CreatePlantRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();
        
        RuleFor(x => x.Cnpj)
            .NotEmpty();
        
        RuleFor(x => x.Address.City)
            .NotEmpty();
        
        RuleFor(x => x.Address.State)
            .NotEmpty();
    }
}