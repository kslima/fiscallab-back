using FiscalLabService.App.Dtos;
using FiscalLabService.App.Extensions;
using FiscalLabService.App.Interfaces;
using FiscalLabService.App.Models;
using FiscalLabService.Domain.Entities;
using FiscalLabService.Domain.Interfaces;
using FiscalLabService.Shared.Responses;

namespace FiscalLabService.App.Services;

public class AssociationService : IAssociationService
{
    private readonly IAssociationRepository _associationRepository;

    public AssociationService(IAssociationRepository associationRepository)
    {
        _associationRepository = associationRepository;
    }
    
    public async Task<Result<UpsertAssociationDto>> UpsertAsync(UpsertAssociationModel model)
    {
        var toUpsertAssociationsIds = model.Associations.Select(a => a.Id).ToList();
        var existingAssociations = await _associationRepository.GetByIdsAsync(toUpsertAssociationsIds);

        var toUpdateAssociations = new List<Association>();
        var toInsertAssociations = new List<Association>();
        
        foreach (var associationModel in model.Associations)
        {
            var toUpsertAssociation = existingAssociations.Find(a => a.Id.Equals(associationModel.Id));
            if (toUpsertAssociation is null)
            {
                toInsertAssociations.Add(associationModel.AsAssociation());
                continue;
            }
            
            toUpdateAssociations.Add(associationModel.AsAssociation());
        }
        
        var updatedAssociations = await _associationRepository.UpdateManyAsync(toUpdateAssociations);
        var insertedAssociations = await _associationRepository.CreateManyAsync(toInsertAssociations);
        
        var allAssociations = insertedAssociations
            .Concat(updatedAssociations)
            .Select(a => a.AsAssociationDto())
            .ToList();

        var dto = new UpsertAssociationDto { Associations = allAssociations };
        return Result<UpsertAssociationDto>.Success(dto);
    }

    public async Task<Result<List<AssociationDto>>> GetAllAsync()
    {
        var associations = await _associationRepository.GetAllAsync();

        var plantsDto = associations.Select(a => a.AsAssociationDto()).ToList();
        return Result<List<AssociationDto>>
            .Success(plantsDto);
    }
}