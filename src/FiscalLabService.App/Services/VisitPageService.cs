using FiscalLabService.App.Dtos;
using FiscalLabService.App.Extensions;
using FiscalLabService.App.Interfaces;
using FiscalLabService.Domain.Interfaces;
using FiscalLabService.Shared.Responses;

namespace FiscalLabService.App.Services;

public class VisitPageService(IVisitPageRepository visitPageRepository) : IVisitPageService
{
    public async Task<Result<List<VisitPageDto>>> GetAllAsync()
    {
        var visitPages = await visitPageRepository.ListAsync();
        var dtos = visitPages.Select(v => v.AsVisitPageDto()).ToList();
        return Result<List<VisitPageDto>>.Success(dtos);
    }
}