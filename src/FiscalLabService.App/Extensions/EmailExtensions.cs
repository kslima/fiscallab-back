using FiscalLabService.App.Dtos;
using FiscalLabService.App.Dtos.Shared;
using FiscalLabService.Domain.ValueObjects;

namespace FiscalLabService.App.Extensions;

public static class EmailExtensions
{
    public static Email AsEmail(this EmailDto emailDto)
    {
        return new Email(emailDto.Address);
    }
    
    public static EmailDto AsEmailDto(this Email email)
    {
        return new EmailDto
        {
            Address = email.Address,
        };
    }
}