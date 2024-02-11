using FiscalLabService.App.Interfaces;
using FiscalLabService.App.Models;
using Microsoft.AspNetCore.Mvc;

namespace FiscalLabService.API.Controllers;

[ApiController]
[Route("synchronization")]
public class SyncController(ISyncService syncService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> SyncDataASync(SyncModel model)
    {
        var result = await syncService.SyncDataASync(model);
        if (result.IsFailure) return BadRequest(result);
        return Ok(result);
    }
}