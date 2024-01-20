using FiscalLabService.App.Dtos;
using FiscalLabService.App.Models;
using FiscalLabService.Shared.Responses;

namespace FiscalLabService.App.Interfaces;

public interface IAssociationService
{
    Task<Result<UpsertAssociationDto>> UpsertAsync(UpsertAssociationModel model);
    Task<Result<List<AssociationDto>>> GetAllAsync();
}