using FiscalLabService.App.Dtos;
using FiscalLabService.App.Models;
using FiscalLabService.Shared.Responses;

namespace FiscalLabService.App.Interfaces;

public interface IMenuService
{
    Task<Result<UpsertMenusDto>> UpsertAsync(UpsertMenusModel model);
    Task<Result<List<MenuDto>>> GetAllAsync();
}