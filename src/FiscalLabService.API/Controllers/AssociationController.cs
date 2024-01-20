using FiscalLabService.App.Interfaces;
using FiscalLabService.App.Models;
using Microsoft.AspNetCore.Mvc;

namespace FiscalLabService.API.Controllers;

[ApiController]
[Route("associations")]
public class AssociationController : ControllerBase
{
    private readonly IAssociationService _associationService;

    public AssociationController(IAssociationService associationService)
    {
        _associationService = associationService;
    }

    [HttpPost("upsert")]
    public async Task<IActionResult> UpsertAsync(UpsertAssociationsModel model)
    {
        var result = await _associationService.UpsertAsync(model);
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _associationService.GetAllAsync();
        return Ok(result);
    }
}