using FiscalLabService.App.Dtos;
using FiscalLabService.App.Dtos.Request;
using FiscalLabService.App.Dtos.Response;
using FiscalLabService.App.Extensions;
using FiscalLabService.App.Interfaces;
using FiscalLabService.App.Resources;
using FiscalLabService.Domain.Interfaces;
using FiscalLabService.Shared.Responses;
using FluentValidation;

namespace FiscalLabService.App.Services;

public class PlantService : IPlantService
{
    private readonly IPlantRepository _plantRepository;
    private readonly IValidator<CreatePlantRequest> _createPlantValidator;
    private readonly ValidationMessageOptions _validationMessages;

    public PlantService(
        IPlantRepository plantRepository,
        IValidator<CreatePlantRequest> createPlantValidator,
        ValidationMessageOptions validationMessages)
    {
        _plantRepository = plantRepository;
        _createPlantValidator = createPlantValidator;
        _validationMessages = validationMessages;
    }

    public async Task<Result<CreatePlantResponse>> CreateAsync(CreatePlantRequest request)
    {
        var validationResult = await _createPlantValidator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            var error = validationResult.Errors.ElementAt(0);
            return Result<CreatePlantResponse>.Failure(new Error(error.ErrorCode, error.ErrorMessage));
        }

        var plantAlreadyExists = await _plantRepository.ExistsAsync(p => p.Cnpj.Equals(request.Cnpj));
        if (plantAlreadyExists)
        {
            return Result<CreatePlantResponse>.Failure(new Error(_validationMessages.DuplicatedPlantCode,
                _validationMessages.DuplicatedPlantMessage));
        }

        var plant = await _plantRepository.CreateAsync(request.AsPlant());
        return Result<CreatePlantResponse>.Success(plant.AsCreatePlantResponse());
    }
    
    public async Task<Result<CreatePlantResponse>> UpdateAsync(string id, CreatePlantRequest request)
    {
        var validationResult = await _createPlantValidator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            var error = validationResult.Errors.ElementAt(0);
            return Result<CreatePlantResponse>.Failure(new Error(error.ErrorCode, error.ErrorMessage));
        }

        var plantExists = await _plantRepository.ExistsAsync(p => p.Id.Equals(id));
        if (!plantExists)
        {
            return Result<CreatePlantResponse>.Failure(new Error(_validationMessages.PlantNotFoundCode,
                _validationMessages.PlantNotFoundMessage));
        }
        
        var plant = await _plantRepository.UpdateAsync(id, request.AsPlant());
        return Result<CreatePlantResponse>.Success(plant.AsCreatePlantResponse());
    }
    
    public async Task<Result<List<PlantDto>>> GetAllAsync()
    {
        var plants = await _plantRepository.ListAsync();

        var plantsDto = plants.Select(p => p.AsPlantDto()).ToList();
        return Result<List<PlantDto>>
            .Success(plantsDto);
    }
}