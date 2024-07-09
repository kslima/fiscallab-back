using FiscalLabService.App.Dtos;
using FiscalLabService.App.Dtos.Request;
using FiscalLabService.App.Dtos.Response;
using FiscalLabService.App.Dtos.Shared;
using FiscalLabService.Domain.Entities;
using FiscalLabService.Domain.ValueObjects;

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
    
    public static Association AsAssociation(this CreateAssociationRequest request)
    {
        return new Association
        {
            Id = Guid.NewGuid().ToString(),
            Name = request.Name,
            Emails = request.Emails.Select(x => x.AsEmail()).ToList(),
            Address = new Address
            {
                City = request.Address.City,
                State = request.Address.State
            }
        };
    }
    
    public static CreateAssociationResponse AsCreateAssociationRequest(this Association association)
    {
        return new CreateAssociationResponse
        {
            Id = association.Id,
            Name = association.Name,
            Emails = association.Emails.Select(x => x.AsEmailDto()).ToList(),
            Address = new AddressDto
            {
                City = association.Address.City,
                State = association.Address.State
            }
        };
    }
}