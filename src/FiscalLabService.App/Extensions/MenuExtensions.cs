using FiscalLabService.App.Dtos;
using FiscalLabService.Domain.Entities;

namespace FiscalLabService.App.Extensions;

public static class MenuExtensions
{
    public static Menu AsMenu(this MenuDto menuDto)
    {
        return new Menu
        {
            Id = menuDto.Id,
            Page = menuDto.Page,
            Code = menuDto.Code,
            Options = menuDto.Options.Select(o => o.AsOption()).ToList()
        };
    }
    
    public static MenuDto AsMenuDto(this Menu menuDto)
    {
        return new MenuDto
        {
            Id = menuDto.Id,
            Page = menuDto.Page,
            Code = menuDto.Code,
            Options = menuDto.Options.Select(o => o.AsOptionDto()).ToList()
        };
    }
}