using FiscalLabService.API.Extensions;
using FiscalLabService.App.Dtos.Request;
using FiscalLabService.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FiscalLabService.API.Controllers;

[ApiController]
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
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] string id)
    {
        var response = await _plantService.DeleteAsync(id);
        return Accepted(response);
    }
    
    [HttpGet]
    public async Task<IActionResult> ListAsync()
    {
        var result = await _plantService.ListAsync();
        return Ok(result);
    }
}