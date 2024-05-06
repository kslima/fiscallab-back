using FiscalLabService.App.Dtos.Request;
using FluentValidation;

namespace FiscalLabService.App.Validators;

public class CreateAssociationRequestValidator : AbstractValidator<CreateAssociationRequest>
{
    public CreateAssociationRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();
        
        RuleFor(x => x.Emails)
            .NotEmpty();
        
        RuleFor(x => x.Address.City)
            .NotEmpty();
        
        RuleFor(x => x.Address.State)
            .NotEmpty();
    }
}