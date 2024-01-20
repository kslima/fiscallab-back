using FiscalLabService.App.Dtos;
using FiscalLabService.App.Extensions;
using FiscalLabService.App.Interfaces;
using FiscalLabService.App.Models;
using FiscalLabService.Domain.Entities;
using FiscalLabService.Domain.Interfaces;
using FiscalLabService.Shared.Responses;

namespace FiscalLabService.App.Services;

public class MenuService : IMenuService
{
    private readonly IMenuRepository _menuRepository;

    public MenuService(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }
    public async Task<Result<UpsertMenusDto>> UpsertAsync(UpsertMenusModel model)
    {
        var menuIds = model.Menus.Select(a => a.Id).ToList();
        var existingMenus = await _menuRepository.GetByIdsAsync(menuIds);

        var toUpdateMenus = new List<Menu>();
        var toInsertMenus = new List<Menu>();
        
        foreach (var menuModel in model.Menus)
        {
            var toUpsertMenu = existingMenus.Find(a => a.Id.Equals(menuModel.Id));
            if (toUpsertMenu is null)
            {
                toInsertMenus.Add(menuModel.AsMenu());
                continue;
            }
            
            toUpdateMenus.Add(menuModel.AsMenu());
        }
        
        var updatedMenus = await _menuRepository.UpdateManyAsync(toUpdateMenus);
        var insertedMenus = await _menuRepository.CreateManyAsync(toInsertMenus);
        
        var allMenus = insertedMenus
            .Concat(updatedMenus)
            .Select(a => a.AsMenuDto())
            .ToList();

        var dto = new UpsertMenusDto { Menus = allMenus };
        return Result<UpsertMenusDto>.Success(dto);
    }

    public async Task<Result<List<MenuDto>>> GetAllAsync()
    {
        var menus = await _menuRepository.GetAllAsync();

        var menusDto = menus.Select(a => a.AsMenuDto()).ToList();
        return Result<List<MenuDto>>
            .Success(menusDto);
    }
}