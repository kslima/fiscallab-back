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
        var result = await _plantService.UpsertPlantAsync(model);
        return Ok(result);
    }
}