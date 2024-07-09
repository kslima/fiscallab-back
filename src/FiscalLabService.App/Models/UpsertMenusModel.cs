using FiscalLabService.App.Dtos;
using FiscalLabService.App.Dtos.Shared;

namespace FiscalLabService.App.Models;

public class UpsertMenusModel
{
    public List<MenuDto> Menus { get; set; } = [];
}