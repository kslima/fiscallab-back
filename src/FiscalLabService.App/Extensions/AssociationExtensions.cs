using FiscalLabService.App.Dtos;
using FiscalLabService.Domain.Entities;

namespace FiscalLabService.App.Extensions;

public static class AssociationExtensions
{
    public static Association AsAssociation(this AssociationDto associationDto)
    {
        return new Association
        {
            Id = associationDto.Id,
            Name = associationDto.Name,
            Address = associationDto.Address.AsAddress(),
            Emails = associationDto.Emails.Select(e => e.AsEmail()).ToList()
        };
    }
    
    public static AssociationDto AsAssociationDto(this Association association)
    {
        return new AssociationDto
        {
            Id = association.Id,
            Name = association.Name,
            Address = association.Address.AsAddressDto(),
            Emails = association.Emails.Select(e => e.AsEmailDto()).ToList()
        };
    }
}