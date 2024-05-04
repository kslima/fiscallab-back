using FiscalLabService.API.Extensions;
using FiscalLabService.App.Dtos.Request;
using FiscalLabService.App.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FiscalLabService.API.Controllers;

[ApiController, Authorize]
[Route("plants")]
public class PlantController : ControllerBase
{
    private readonly IPlantService _plantService;

    public PlantController(IPlantService plantService)
    {
        _plantService = plantService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreatePlantRequest request)
    {
        var result = await _plantService.CreateAsync(request);
        return result.IsFailure
            ? StatusCode(result.Error!.Code.GetErrorStatusCode(), result)
            : Created(string.Empty, result);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] string id, CreatePlantRequest request)
    {
        var result = await _plantService.UpdateAsync(id, request);
        return result.IsFailure
            ? StatusCode(result.Error!.Code.GetErrorStatusCode(), result)
            : Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _plantService.GetAllAsync();
        return Ok(result);
    }
}