using FiscalLabService.App.Dtos;
using FiscalLabService.App.Dtos.Shared;
using FiscalLabService.Shared.Responses;

namespace FiscalLabService.App.Interfaces;

public interface IVisitPageService
{
    Task<Result<List<VisitPageDto>>> GetAllAsync();
}