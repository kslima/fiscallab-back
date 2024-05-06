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
    IMenuRepository menuRepository,
    IVisitRepository visitRepository)
    : ISyncService
{
    public async Task<Result<SyncResult>> SyncDataASync(SyncModel syncModel)
    {
        var plants = await plantRepository.GetByIdsAsync(syncModel.Visits.Select(x => x.BasicInformation.PlantId).ToList());
        var associations = await associationRepository.GetByIdsAsync(syncModel.Visits.Select(x => x.BasicInformation.AssociationId).ToList());
        syncModel.Visits.ToList().ForEach(x =>
        {
            x.BasicInformation.Plant = plants.Single(a => a.Id.Equals(x.BasicInformation.PlantId));
            x.BasicInformation.Association = associations.Single(a => a.Id.Equals(x.BasicInformation.AssociationId));
            x.SyncedAt = DateTime.UtcNow;
        });
        var visits = await SyncVisits(syncModel.Visits);
        return Result<SyncResult>.Success(new SyncResult
        {
            Visits = visits
        });
    }

    private async Task<Plant[]> SyncPlantsASync(Plant[] plants)
    {
        if (plants.Length == 0) return (await plantRepository.ListAsync()).ToArray();
        var toUpsertPlantIds = plants.Select(p => p.Id).ToList();
        var existingPlants = await plantRepository.GetByIdsAsync(toUpsertPlantIds);

        var toUpdatePlants = new List<Plant>();
        var toInsertPlants = new List<Plant>();

        foreach (var plant in plants)
        {
            var toUpsertPlant = existingPlants.Find(p => p.Id.Equals(plant.Id));
            if (toUpsertPlant is null)
            {
                toInsertPlants.Add(plant);
                continue;
            }

            toUpdatePlants.Add(plant);
        }

        var updatedPlants = await plantRepository.UpdateManyAsync(toUpdatePlants);
        var insertedPlants = await plantRepository.CreateManyAsync(toInsertPlants);

        return insertedPlants
            .Concat(updatedPlants)
            .ToArray();
    }

    private async Task<Association[]> SyncAssociations(Association[] associations)
    {
        if (associations.Length == 0) return (await associationRepository.ListAsync()).ToArray();
        var toUpsertAssociationsIds = associations.Select(a => a.Id).ToList();
        var existingAssociations = await associationRepository.GetByIdsAsync(toUpsertAssociationsIds);

        var toUpdateAssociations = new List<Association>();
        var toInsertAssociations = new List<Association>();

        foreach (var association in associations)
        {
            var toUpsertAssociation = existingAssociations.Find(a => a.Id.Equals(association.Id));
            if (toUpsertAssociation is null)
            {
                toInsertAssociations.Add(association);
                continue;
            }

            toUpdateAssociations.Add(association);
        }

        var updatedAssociations = await associationRepository.UpdateManyAsync(toUpdateAssociations);
        var insertedAssociations = await associationRepository.CreateManyAsync(toInsertAssociations);

        return insertedAssociations
            .Concat(updatedAssociations)
            .ToArray();
    }

    private async Task<Menu[]> SyncMenus(Menu[] menus)
    {
        if (menus.Length == 0) return (await menuRepository.ListAsync()).ToArray();
        var menuIds = menus.Select(a => a.Id).ToList();
        var existingMenus = await menuRepository.GetByIdsAsync(menuIds);

        var toUpdateMenus = new List<Menu>();
        var toInsertMenus = new List<Menu>();

        foreach (var menu in menus)
        {
            var toUpsertMenu = existingMenus.Find(a => a.Id.Equals(menu.Id));
            if (toUpsertMenu is null)
            {
                toInsertMenus.Add(menu);
                continue;
            }

            toUpdateMenus.Add(menu);
        }

        var updatedMenus = await menuRepository.UpdateManyAsync(toUpdateMenus);
        var insertedMenus = await menuRepository.CreateManyAsync(toInsertMenus);

        return insertedMenus
            .Concat(updatedMenus)
            .ToArray();
    }

    private async Task<Visit[]> SyncVisits(IReadOnlyCollection<Visit> visits)
    {
        if (visits.Count == 0) return (await visitRepository.ListAsync()).ToArray();
        var visitIds = visits.Select(a => a.Id).ToArray();
        var existingVisits = await visitRepository.GetByIdsAsync(visitIds);

        var toUpdateVisits = new List<Visit>();
        var toInsertVisits = new List<Visit>();
        var toDeleteVisits = new List<Visit>();

        foreach (var visit in visits)
        {
            if (visit.Status == VisitStatus.Cancelled)
            {
                toDeleteVisits.Add(visit);
                continue;
            }
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
        await visitRepository.DeleteManyAsync(toDeleteVisits);

        return (await visitRepository.ListAsync()).ToArray();
    }
}