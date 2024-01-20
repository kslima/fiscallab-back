using FiscalLabService.App.Dtos;
using FiscalLabService.App.Models;
using FiscalLabService.Shared.Responses;

namespace FiscalLabService.App.Interfaces;

public interface IAssociationService
{
    Task<Result<UpsertAssociationsDto>> UpsertAsync(UpsertAssociationsModel model);
    Task<Result<List<AssociationDto>>> GetAllAsync();
}