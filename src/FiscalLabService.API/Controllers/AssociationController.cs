using FiscalLabService.API.Extensions;
using FiscalLabService.App.Dtos.Request;
using FiscalLabService.App.Interfaces;
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

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateAssociationRequest request)
    {
        var result = await _associationService.CreateAsync(request);
        return result.IsFailure
            ? StatusCode(result.Error!.Code.GetErrorStatusCode(), result)
            : Created(string.Empty, result);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] string id, CreateAssociationRequest request)
    {
        var result = await _associationService.UpdateAsync(id, request);
        return result.IsFailure
            ? StatusCode(result.Error!.Code.GetErrorStatusCode(), result)
            : Ok(result);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] string id)
    {
        var response = await _associationService.DeleteAsync(id);
        return Accepted(response);
    }
    
    [HttpGet]
    public async Task<IActionResult> ListAsync()
    {
        var result = await _associationService.ListAsync();
        return Ok(result);
    }
}