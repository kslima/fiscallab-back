using FiscalLabService.Domain.Entities;

namespace FiscalLabService.Domain.Interfaces;

public interface IMenuRepository
{
    Task<List<Menu>> CreateManyAsync(List<Menu> menus);
    Task<List<Menu>> UpdateManyAsync(List<Menu> menus);
    Task<List<Menu>> GetByIdsAsync(List<string> ids);
    Task<List<Menu>> GetAllAsync();
}