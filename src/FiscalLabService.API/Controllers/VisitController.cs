using FiscalLabService.App.Interfaces;
using FiscalLabService.App.Models;
using Microsoft.AspNetCore.Mvc;

namespace FiscalLabService.API.Controllers;

[ApiController]
[Route("visits")]
public class VisitController(IVisitService visitService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] VisitModel visitModel)
    {
        var result = await visitService.CreateAsync(visitModel);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> ListAsync()
    {
        var result = await visitService.ListAsync();
        return Ok(result);
    }
}