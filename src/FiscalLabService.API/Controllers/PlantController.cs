using FiscalLabService.App.Interfaces;
using FiscalLabService.App.Models;
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

    [HttpPost("upsert")]
    public async Task<IActionResult> UpsertAsync(UpsertPlantsModel model)
    {
        var result = await _plantService.UpsertAsync(model);
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _plantService.GetAllAsync();
        return Ok(result);
    }
}