using FiscalLabService.App.Dtos;

namespace FiscalLabService.App.Models;

public class UpsertMenusModel
{
    public List<MenuDto> Menus { get; set; } = [];
}