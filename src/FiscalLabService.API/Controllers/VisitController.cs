using FiscalLabService.App.Documents;
using FiscalLabService.App.Dtos.Request;
using FiscalLabService.App.Extensions;
using FiscalLabService.App.Interfaces;
using FiscalLabService.App.Models;
using FiscalLabService.Domain.Entities;
using FiscalLabService.Domain.Interfaces;
using FiscalLabService.Shared.Responses;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;

namespace FiscalLabService.API.Controllers;

[ApiController]
[Route("visits")]
public class VisitController : ControllerBase
{
    private readonly IVisitService _visitService;
    private readonly IVisitRepository _visitRepository;

    public VisitController(IVisitService visitService, IVisitRepository visitRepository)
    {
        _visitService = visitService;
        _visitRepository = visitRepository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateManyAsync([FromBody] VisitModel[] visitModels)
    {
        var result = await _visitService.CreateManyAsync(visitModels);
        return Ok(result);
    }
    
    [HttpPost("upsert")]
    public async Task<IActionResult> UpsertAsync([FromBody] List<VisitModel> visitModels)
    {
        var result = await _visitService.UpsertAsync(visitModels);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> ListAsync([FromQuery] VisitQueryParameters parameters)
    {
        var result = await _visitRepository.ListAsync(parameters.AsVisitParameters());
        var response = Result<List<Visit>>.Success(result);
        response.Metadata = result.AsMetadata();
        
        return Ok(response);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] string id)
    {
        var response = await _visitService.DeleteAsync(id);
        return Accepted(response);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute] string id)
    {
        var visit = await _visitService.GetByIdAsync(id);
        return Ok(visit);
    }
    
    [HttpGet("{id}/pdf")]
    public async Task<IActionResult> GeneratePdfAsync([FromRoute] string id)
    {
        var visit = await _visitService.GetByIdAsync(id);
        
        var pdf = new VisitDocument(visit.Data!);
        var pdfBytes = pdf.GeneratePdf();
        return File(pdfBytes, "application/pdf", "visit.pdf");
    }
}