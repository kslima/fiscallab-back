using FiscalLabService.App.Dtos.Shared;
using FiscalLabService.App.Extensions;
using FiscalLabService.App.Interfaces;
using FiscalLabService.App.Models;
using FiscalLabService.Domain.Entities;
using FiscalLabService.Domain.Enums;
using FiscalLabService.Domain.Interfaces;
using FiscalLabService.Shared.Responses;

namespace FiscalLabService.App.Services;

public class VisitService : IVisitService
{
    private readonly IVisitRepository _visitRepository;
    private readonly IPlantRepository _plantRepository;
    private readonly IAssociationRepository _associationRepository;

    public VisitService(
        IVisitRepository visitRepository,
        IPlantRepository plantRepository,
        IAssociationRepository associationRepository)
    {
        _visitRepository = visitRepository;
        _plantRepository = plantRepository;
        _associationRepository = associationRepository;
    }

    public async Task<Result<VisitDto>> CreateAsync(VisitModel visitModel)
    {
        var visit = visitModel.AsVisit();

        visit = await _visitRepository.CreateAsync(visit);
        return Result<VisitDto>.Success(visit.AsVisitDto());
    }

    public async Task<Result<bool>> CreateManyAsync(VisitModel[] visitModels)
    {
        var visits = visitModels.Select(x => x.AsVisit()).ToList();
        await _visitRepository.CreateManyAsync(visits);
        return Result<bool>.Success(true);
    }

    public async Task<Result<bool>> UpsertAsync(List<VisitModel> visitModels)
    {
        var planIds = visitModels
            .Select(x => x.BasicInformation.Plant.Id)
            .ToList();

        var plants = await _plantRepository.GetByIdsAsync(planIds);

        var associationIds = visitModels
            .Select(x => x.BasicInformation.Association.Id)
            .ToList();
        var associations = await _associationRepository.GetByIdsAsync(associationIds);

        var visits = visitModels
            .Select(x => x.AsVisit())
            .ToList();

        visits.ForEach(x =>
        {
            x.BasicInformation.Plant = plants.Single(a => a.Id.Equals(x.BasicInformation.PlantId));
            x.BasicInformation.Association = associations.Single(a => a.Id.Equals(x.BasicInformation.AssociationId));
            x.SyncedAt = DateTime.UtcNow;
        });

        var visitIds = visits
            .Where(v => v.Status != VisitStatus.Done)
            .Select(a => a.Id)
            .ToArray();

        var existingVisits = await _visitRepository.GetByIdsAsync(visitIds);
        var toUpdateVisits = new List<Visit>();
        var toInsertVisits = new List<Visit>();

        foreach (var visit in visits)
        {
            var toUpsertVisit = existingVisits.Find(a => a.Id.Equals(visit.Id));
            if (toUpsertVisit is null)
            {
                toInsertVisits.Add(visit);
                continue;
            }

            toUpdateVisits.Add(visit);
        }

        await _visitRepository.UpdateManyAsync(toUpdateVisits);
        await _visitRepository.CreateManyAsync(toInsertVisits);

        return Result<bool>.Success(true);
    }

    public async Task<Result<List<VisitDto>>> ListAsync()
    {
        var visits = await _visitRepository.ListAsync();
        var dtos = visits.Select(v => v.AsVisitDto()).ToList();
        return Result<List<VisitDto>>.Success(dtos);
    }

    public async Task<Result<VisitDto>> GetByIdAsync(string id)
    {
        var visit = await _visitRepository.GetById(id);
        return Result<VisitDto>.Success(visit.AsVisitDto());
    }

    public async Task<Result<bool>> DeleteAsync(string id)
    {
        var deleteResult = await _visitRepository.DeleteAsync(id);
        return deleteResult == 1 ? Result<bool>.Success(true) : Result<bool>.Failure(Error.None);
    }
}