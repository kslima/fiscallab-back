using FiscalLabService.App.Dtos;
using FiscalLabService.App.Dtos.Request;
using FiscalLabService.App.Dtos.Response;
using FiscalLabService.App.Extensions;
using FiscalLabService.App.Interfaces;
using FiscalLabService.App.Models;
using FiscalLabService.App.Resources;
using FiscalLabService.Domain.Entities;
using FiscalLabService.Domain.Interfaces;
using FiscalLabService.Shared.Responses;
using FluentValidation;

namespace FiscalLabService.App.Services;

public class AssociationService : IAssociationService
{
    private readonly IAssociationRepository _associationRepository;
    private readonly IValidator<CreateAssociationRequest> _createAssociationValidator;
    private readonly ValidationMessageOptions _validationMessages;

    public AssociationService(
        IAssociationRepository associationRepository,
        IValidator<CreateAssociationRequest> createAssociationValidator,
        ValidationMessageOptions validationMessages)
    {
        _associationRepository = associationRepository;
        _createAssociationValidator = createAssociationValidator;
        _validationMessages = validationMessages;
    }

    public async Task<Result<CreateAssociationResponse>> CreateAsync(CreateAssociationRequest request)
    {
        var validationResult = await _createAssociationValidator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            var error = validationResult.Errors.ElementAt(0);
            return Result<CreateAssociationResponse>.Failure(new Error(error.ErrorCode, error.ErrorMessage));
        }

        var associationAlreadyExists = await _associationRepository.ExistsAsync(p => p.Name.Equals(request.Name));
        if (associationAlreadyExists)
        {
            return Result<CreateAssociationResponse>.Failure(new Error(_validationMessages.DuplicatedAssociationCode,
                _validationMessages.DuplicatedAssociationMessage));
        }

        var association = await _associationRepository.CreateAsync(request.AsAssociation());
        return Result<CreateAssociationResponse>.Success(association.AsCreateAssociationRequest());
    }

    public async Task<Result<CreateAssociationResponse>> UpdateAsync(string id, CreateAssociationRequest request)
    {
        var validationResult = await _createAssociationValidator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            var error = validationResult.Errors.ElementAt(0);
            return Result<CreateAssociationResponse>
                .Failure(new Error(error.ErrorCode, error.ErrorMessage));
        }

        var associationExists = await _associationRepository.ExistsAsync(p => p.Id.Equals(id));
        if (!associationExists)
        {
            return Result<CreateAssociationResponse>
                .Failure(new Error(_validationMessages.AssociationNotFoundCode,
                _validationMessages.AssociationNotFoundMessage));
        }

        var association = await _associationRepository.UpdateAsync(id, request.AsAssociation());
        return Result<CreateAssociationResponse>.Success(association.AsCreateAssociationRequest());
    }

    public async Task<Result<UpsertAssociationsDto>> UpsertAsync(UpsertAssociationsModel model)
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

        var dto = new UpsertAssociationsDto { Associations = allAssociations };
        return Result<UpsertAssociationsDto>.Success(dto);
    }

    public async Task<Result<List<AssociationDto>>> ListAsync()
    {
        var associations = await _associationRepository.ListAsync();

        var plantsDto = associations.Select(a => a.AsAssociationDto()).ToList();
        return Result<List<AssociationDto>>
            .Success(plantsDto);
    }
}