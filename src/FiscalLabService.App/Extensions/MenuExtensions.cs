using FiscalLabService.App.Dtos;
using FiscalLabService.App.Dtos.Shared;
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
            Name = menuDto.Name,
            DisplayName = menuDto.DisplayName,
            HasPercentageOptions = menuDto.HasPercentageOptions,
            Options = menuDto.Options.Select(o => o.AsOption()).ToList()
        };
    }
    
    public static MenuDto AsMenuDto(this Menu menu)
    {
        return new MenuDto
        {
            Id = menu.Id,
            Page = menu.Page,
            Name = menu.Name,
            DisplayName = menu.DisplayName,
            HasPercentageOptions = menu.HasPercentageOptions,
            Options = menu.Options.Select(o => o.AsOptionDto()).ToList()
        };
    }
}