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

    [HttpPost]
    public async Task<IActionResult> CreateAsync(PlantModel model)
    {
        var plant = await _plantService.CreateAsync(model);
        return Created(string.Empty, plant);
    }

    [HttpPut("{plantId}/emails")]

    public async Task<IActionResult> AddEmailAsync([FromRoute] long plantId, [FromBody] AddEmailModel model)
    {
        var plant = await _plantService.AddEmailAsync(plantId, model);
        return Ok(plant);
    }
    
    [HttpDelete("{plantId}/emails/{email}")]

    public async Task<IActionResult> RemoveEmailAsync([FromRoute] long plantId, [FromRoute] string email)
    {
        await _plantService.RemoveEmailAsync(plantId, email);
        return Accepted();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _plantService.GetAllAsync());
    }
}