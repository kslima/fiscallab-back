using FiscalLabService.App.Documents;
using FiscalLabService.App.Interfaces;
using FiscalLabService.App.Models;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;

namespace FiscalLabService.API.Controllers;

[ApiController]
[Route("visits")]
public class VisitController(IVisitService visitService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] VisitModel[] visitModels)
    {
        var result = await visitService.CreateManyAsync(visitModels);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> ListAsync()
    {
        var result = await visitService.ListAsync();
        return Ok(result);
    }
    
    [HttpGet("{id}/pdf")]
    public async Task<IActionResult> GeneratePdf([FromRoute] string id)
    {
        var visit = await visitService.GetByIdAsync(id);
        
        var pdf = new VisitDocument(visit.Data!);
        var pdfBytes = pdf.GeneratePdf();
        return File(pdfBytes, "application/pdf", "visit.pdf");
    }
}