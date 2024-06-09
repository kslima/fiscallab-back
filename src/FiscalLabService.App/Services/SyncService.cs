using FiscalLabService.App.Interfaces;
using FiscalLabService.App.Models;
using FiscalLabService.Domain.Entities;
using FiscalLabService.Domain.Enums;
using FiscalLabService.Domain.Interfaces;
using FiscalLabService.Shared.Responses;

namespace FiscalLabService.App.Services;

public class SyncService(
    IPlantRepository plantRepository,
    IAssociationRepository associationRepository,
    IVisitRepository visitRepository)
    : ISyncService
{
    public async Task<Result<SyncResult>> SyncDataASync(SyncModel syncModel)
    {
        var plants = await plantRepository.GetByIdsAsync(syncModel.Visits.Select(x => x.BasicInformation.Plant.Id).ToList());
        var associations = await associationRepository.GetByIdsAsync(syncModel.Visits.Select(x => x.BasicInformation.Association.Id).ToList());
        syncModel.Visits.ToList().ForEach(x =>
        {
            x.BasicInformation.Plant = plants.Single(a => a.Id.Equals(x.BasicInformation.Plant.Id));
            x.BasicInformation.Association = associations.Single(a => a.Id.Equals(x.BasicInformation.Association.Id));
            x.SyncedAt = DateTime.UtcNow;
        });
        var visits = await SyncVisits(syncModel.Visits);
        return Result<SyncResult>.Success(new SyncResult
        {
            Visits = visits
        });
    }
    
    private async Task<Visit[]> SyncVisits(IReadOnlyCollection<Visit> visits)
    {
        if (visits.Count == 0) return (await visitRepository.ListAsync()).ToArray();
        
        var visitIds = visits
            .Where(v => v.Status != VisitStatus.Done)
            .Select(a => a.Id).ToArray();
        
        var existingVisits = await visitRepository.GetByIdsAsync(visitIds);

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

        await visitRepository.UpdateManyAsync(toUpdateVisits);
        await visitRepository.CreateManyAsync(toInsertVisits);
        
        return (await visitRepository.ListAsync()).ToArray();
    }
}