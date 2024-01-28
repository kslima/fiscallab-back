using FiscalLabService.App.Dtos;
using FiscalLabService.App.Extensions;
using FiscalLabService.App.Interfaces;
using FiscalLabService.App.Models;
using FiscalLabService.Domain.Interfaces;
using FiscalLabService.Shared.Responses;

namespace FiscalLabService.App.Services;

public class VisitService(IVisitRepository visitRepository) : IVisitService
{
    public async Task<Result<VisitDto>> CreateAsync(VisitModel visitModel)
    {
        var visit = visitModel.AsVisit();
        
        visit = await visitRepository.CreateAsync(visit);
        return Result<VisitDto>.Success(visit.AsVisitDto());
    }

    public async Task<Result<List<VisitDto>>> ListAsync()
    {
        var visits = await visitRepository.ListAsync();
        var dtos = visits.Select(v => v.AsVisitDto()).ToList();
        return Result<List<VisitDto>>.Success(dtos);
    }

    public async Task<Result<VisitDto>> GetByIdAsync(string id)
    {
        var visit = await visitRepository.GetById(id);
        return Result<VisitDto>.Success(visit.AsVisitDto());
    }
}