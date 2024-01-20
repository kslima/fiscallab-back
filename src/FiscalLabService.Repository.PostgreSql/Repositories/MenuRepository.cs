using FiscalLabService.Domain.Entities;
using FiscalLabService.Domain.Interfaces;
using FiscalLabService.Repository.PostgreSql.Context;
using Microsoft.EntityFrameworkCore;

namespace FiscalLabService.Repository.PostgreSql.Repositories;

public class MenuRepository : IMenuRepository
{
    private readonly ApplicationContext _context;
    public MenuRepository(ApplicationContext context)
    {
        _context = context;
    }
    
    public async Task<List<Menu>> CreateManyAsync(List<Menu> menus)
    {
        await _context.Menus.AddRangeAsync(menus);
        await _context.SaveChangesAsync();
        return menus;
    }

    public async Task<List<Menu>> UpdateManyAsync(List<Menu> menus)
    {
        var menuIds = menus.Select(p => p.Id);
        var menusToUpdate = _context.Menus
            .Where(p => menuIds.Contains(p.Id))
            .ToList();
        
        foreach (var menu in menusToUpdate)
        {
            var updatedMenu = menus.First(m => m.Id.Equals(menu.Id));
            menu.Page = updatedMenu.Page;
            menu.Code = updatedMenu.Code;
            menu.Options = updatedMenu.Options;
        }
        
        _context.Menus.UpdateRange(menusToUpdate);
        await _context.SaveChangesAsync();
        return menusToUpdate;
    }

    public async Task<List<Menu>> GetByIdsAsync(List<string> ids)
    {
        return await _context.Menus
            .AsNoTracking()
            .Where(p => ids.Contains(p.Id))
            .ToListAsync();
    }

    public async Task<List<Menu>> GetAllAsync()
    {
        return await _context.Menus
            .AsNoTracking()
            .ToListAsync();
    }
}