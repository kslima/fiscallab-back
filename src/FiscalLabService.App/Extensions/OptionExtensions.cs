using FiscalLabService.App.Dtos;
using FiscalLabService.App.Dtos.Shared;
using FiscalLabService.Domain.ValueObjects;

namespace FiscalLabService.App.Extensions;

public static class OptionExtensions
{
    public static Option AsOption(this OptionDto optionDto)
    {
        return new Option
        {
            Description = optionDto.Description
        };
    }
    
    public static OptionDto AsOptionDto(this Option option)
    {
        return new OptionDto
        {
            Description = option.Description,
        };
    }
}