using FiscalLabService.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FiscalLabService.API.Controllers;

[ApiController]
[Route("visit-pages")]
public class VisitPageController(IVisitPageService visitPageService) : ControllerBase
{
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await visitPageService.GetAllAsync();
        return Ok(result);
    }
}